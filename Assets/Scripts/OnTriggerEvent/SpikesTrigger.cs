using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesTrigger : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TimerCountdown timerCountdown; // Reference to the TimerCountdown script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            // Show the Game Over panel
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            // Stop the player's movement
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

            // Trigger the death animation
            Animator playerAnimator = collision.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
                playerAnimator.SetTrigger("isDead");
            }
        }
    }
}
