using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : View
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _guideButton;
    [SerializeField] private Button _quitButton;

    public override void Initialize()
    {
        _startButton.onClick.AddListener(() => LoadScene("Level1"));
        _creditsButton.onClick.AddListener(() => ViewManager.Show<CreditsMenuView>());
        _guideButton.onClick.AddListener(() => ViewManager.Show<GuideMenuView>());
        _quitButton.onClick.AddListener(() => Application.Quit());

    }
    private void LoadScene(string Level1)
    {
        HeartSystem.life = 3;
        Time.timeScale = 1f;
        SceneManager.LoadScene(Level1);
    }
}
