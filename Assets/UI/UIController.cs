using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button _pauseButton;
    private Button _resumeButton;
    private Button _restartButton;
    private Button _exitGame;

    private VisualElement _pauseLabel;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _pauseButton = root.Q<Button>("PauseButton");
        _resumeButton = root.Q<Button>("Resume");
        _restartButton = root.Q<Button>("Restart");
        _exitGame = root.Q<Button>("Exit");

        _pauseLabel = root.Q<VisualElement>("BackgroundPause");

        _pauseButton.clicked += PauseButtonPressed;
    }

    private void PauseButtonPressed()
    {
        ;
        Time.timeScale = 0;
        _pauseLabel.style.display = DisplayStyle.Flex;

        _resumeButton.clicked += ResumeButtonPressed;
        _restartButton.clicked += RestartButtonPressed;
        _exitGame.clicked += ExitGame;
    }

    private void ResumeButtonPressed()
    {
        _resumeButton.clicked -= ResumeButtonPressed;
        _restartButton.clicked -= RestartButtonPressed;
        _exitGame.clicked -= ExitGame;

        Time.timeScale = 1;
        _pauseLabel.style.display = DisplayStyle.None;
    }

    private void RestartButtonPressed()
    {
        _pauseButton.clicked -= PauseButtonPressed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
