using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverPanel;
    public static int life = 3;

    private bool isGameOver = false;

    void Start()
    {
        life = Mathf.Clamp(life, 0, hearts.Length);

        for (int i = life; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                Destroy(hearts[i]);
            }
        }

        if (life <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TakeDamage(int d)
    {
        if (isGameOver) return;

        life -= d;

        if (life <= 0)
        {
            life = 0;
            TriggerGameOver();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOverPanel is not assigned in the inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
