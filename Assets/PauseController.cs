using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseController : MonoBehaviour
{
    private Button _pauseButton;
    private Button _resumeButton;
    private Button _restartButton;


    private VisualElement _pauseLabel;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _pauseButton = root.Q<Button>("PauseButton");
        _resumeButton = root.Q<Button>("Resume");
        _restartButton = root.Q<Button>("Restart");

        _pauseLabel = root.Q<VisualElement>("BackgroundPause");

        _pauseButton.clicked += PauseButtonPressed;
    }

    private void PauseButtonPressed()
    {;
        Time.timeScale = 0;
        _pauseLabel.style.display = DisplayStyle.Flex;

        _resumeButton.clicked += ResumeButtonPressed;
        _restartButton.clicked += RestartButtonPressed;
    }

    private void ResumeButtonPressed()
    {
        _resumeButton.clicked -= ResumeButtonPressed;
        _restartButton.clicked -= RestartButtonPressed;

        Time.timeScale = 1;
        _pauseLabel.style.display = DisplayStyle.None;
    }

    private void RestartButtonPressed()
    {
        _pauseButton.clicked -= PauseButtonPressed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
