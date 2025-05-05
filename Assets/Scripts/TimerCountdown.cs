using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private bool runningTimer = true;
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime = 40;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;
    }

    void Update()
    {
        if (runningTimer)
        {
            currentTime -= Time.deltaTime;

            if (timerText != null)
            {
                int displayTime = Mathf.Max(0, Mathf.FloorToInt(currentTime));
                timerText.text = $"Time: {displayTime:D1}";
            }

            if (currentTime <= 0)
            {
                runningTimer = false;
                HandlePlayerDeath();
            }
        }
    }
    public void HandlePlayerDeath()
    {
        // Show Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Find the player in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Stop player's movement
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
                playerRb.isKinematic = true;
            }

            // Disable player's movement script
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            // Trigger death animation
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("isDead");
            }
        }
    }
}
