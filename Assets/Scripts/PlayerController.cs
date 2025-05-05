using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D movementFilter;

    private Rigidbody2D rb;
    private Vector2 MovementInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        TryMove(); // Uses raycasting for movement with collision detection
    }

    private void TryMove()
    {
        if (MovementInput != Vector2.zero)
        {
            // First, try full movement
            if (!CheckCollision(MovementInput))
            {
                rb.velocity = MovementInput * moveSpeed;
            }
            else
            {
                // If full movement is blocked, try x-only movement
                if (!CheckCollision(new Vector2(MovementInput.x, 0)))
                {
                    rb.velocity = new Vector2(MovementInput.x, 0) * moveSpeed;
                }
                // If x is blocked, try y-only movement
                else if (!CheckCollision(new Vector2(0, MovementInput.y)))
                {
                    rb.velocity = new Vector2(0, MovementInput.y) * moveSpeed;
                }
                else
                {
                    // If all directions are blocked, stop movement
                    rb.velocity = Vector2.zero;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private bool CheckCollision(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        return count > 0; // Returns true if there's a collision
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastMoveX", MovementInput.x);
            animator.SetFloat("LastMoveY", MovementInput.y);
        }

        MovementInput = context.ReadValue<Vector2>();
        animator.SetFloat("MoveX", MovementInput.x);
        animator.SetFloat("MoveY", MovementInput.y);

        // Flip sprite based on movement direction
        if (MovementInput.x < 0 || (MovementInput.x < 0 && MovementInput.y > 0))
        {
            spriteRenderer.flipX = true;
        }
        else if (MovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
