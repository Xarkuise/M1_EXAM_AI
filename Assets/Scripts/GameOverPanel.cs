using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManager

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(Level2);
    }

    private void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}