using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;

    private void Start()
    {
        // Add listener to button to load the next level
        _nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        // Load the next scene in the build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // Assuming the next level is the next scene in the build list

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("No next level available.");
        }
    }
}