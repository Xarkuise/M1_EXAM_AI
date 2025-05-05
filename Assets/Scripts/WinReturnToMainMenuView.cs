using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinReturnToMainMenuViewl : MonoBehaviour
{
    [SerializeField] private Button _nextNewGameButton;
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _nextNewGameButton.onClick.AddListener(() =>
        {
            Debug.Log("Next New Game button clicked");
            NewGameLevel();
        });

        _mainMenuButton.onClick.AddListener(() =>
        {
            Debug.Log("Main Menu button clicked");
            ReturnToMainMenu();
        });
    }

    private void NewGameLevel()
    {
        // Load Level 1 (assuming it's at build index 1)
        int levelOneIndex = 1;

        // Check if Level 1 exists in the build settings
        if (levelOneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Level 1 is not available in the build settings.");
        }
    }


    private void ReturnToMainMenu()
    {
        // Assuming the main menu is the first scene (index 0) in the build settings
        SceneManager.LoadScene(0);
        
    }
}
