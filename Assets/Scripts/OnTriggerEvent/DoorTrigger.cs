using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorTrigger : MonoBehaviour
{
    public GameObject winPanel;          // The win panel to show when the player wins
    public KeyPickup keyPickup;          // Reference to the KeyPickup script
    private Collider2D doorCollider;     // The collider of the door
    private TilemapRenderer doorRenderer; // The TilemapRenderer of the door

    private void Start()
    {
        // Ensure the doorCollider and doorRenderer are assigned properly
        doorCollider = GetComponent<Collider2D>();
        doorRenderer = GetComponent<TilemapRenderer>();

        // Log to make sure references are assigned
        if (doorCollider == null)
        {
            Debug.LogError("No Collider2D attached to the Door.");
        }

        if (doorRenderer == null)
        {
            Debug.LogError("No TilemapRenderer attached to the Door.");
        }
    }

    private void Update()
    {
        // Disable the door's TilemapRenderer immediately after the key is collected
        if (keyPickup != null && keyPickup.isKeyCollected())
        {
            // Disable the TilemapRenderer to make the door disappear visually
            if (doorRenderer != null && doorRenderer.enabled)
            {
                doorRenderer.enabled = false; // Disable the TilemapRenderer only
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if key is collected before stopping movement
            if (keyPickup != null && keyPickup.isKeyCollected())
            {
                // Stop the player's movement and trigger the win condition
                Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.velocity = Vector2.zero; // Stop movement
                    playerRb.isKinematic = true; // Prevent further movement
                }

                // Disable Player's movement script (if applicable)
                PlayerController playerMovement = collision.GetComponent<PlayerController>();
                if (playerMovement != null)
                {
                    playerMovement.enabled = false;
                }

                // Show the win panel when the player touches the door
                winPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                // If key is not collected, just log the message and let the player move freely
                Debug.Log("Key not collected yet!");
            }
        }
    }
}
