using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    private void Start()
    {
        if (_backButton != null)
        {
            _backButton.onClick.AddListener(GoHome);
        }
        else
        {
            Debug.LogWarning("Back Button is not assigned in the inspector.");
        }

        Time.timeScale = 0f;
    }

    private void GoHome()
    {
        HeartSystem.life = 3;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
