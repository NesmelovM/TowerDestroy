using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private Transform _shieldPosition;
    [SerializeField] private Transform _shieldParent;
    [SerializeField] private float _timeReloadShield;

    private Button _pauseButton;
    private Button _resumeButton;
    private Button _restartButton;
    private Button _exitGame;
    private Button _shieldButton;

    private VisualElement _pauseLabel;
    private VisualElement _timerLabel;
    private Label _timerTextLabel;

    private float _tempTimeReload;
    private bool _canShield;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _pauseButton = root.Q<Button>("PauseButton");
        _resumeButton = root.Q<Button>("Resume");
        _restartButton = root.Q<Button>("Restart");
        _exitGame = root.Q<Button>("Exit");

        _shieldButton = root.Q<Button>("Shield");

        _pauseLabel = root.Q<VisualElement>("BackgroundPause");
        _timerLabel = root.Q<VisualElement>("Timer");
        _timerTextLabel = root.Q<Label>("TimerText");
        _timerTextLabel.text = _tempTimeReload.ToString();

        _pauseButton.clicked += PauseButtonPressed;
        _shieldButton.clicked += ShieldButtonPressed;
    }
    private void Update()
    {
        if (_canShield == false)
        {
            _tempTimeReload -= Time.deltaTime;
            _timerTextLabel.text = _tempTimeReload.ToString().Substring(0,3) ;

            if (_tempTimeReload <= 0)
            {
                _canShield = true;
                _tempTimeReload = _timeReloadShield;

                _timerLabel.style.display = DisplayStyle.None;
            }
        }
    }

    private void ShieldButtonPressed()
    {
        if (_canShield)
        {
            GameObject shield = Instantiate(_shieldPrefab, _shieldPosition.position, _shieldPosition.rotation, _shieldParent);
            _tempTimeReload = 5f;

            _canShield = false;

            _timerLabel.style.display = DisplayStyle.Flex;
        }
    }

    private void PauseButtonPressed()
    {
        Time.timeScale = 0;
        _pauseLabel.style.display = DisplayStyle.Flex;

        _resumeButton.clicked += ResumeButtonPressed;
        _restartButton.clicked += RestartButtonPressed;
        _exitGame.clicked += ExitGame;
        _shieldButton.clicked -= ShieldButtonPressed;
    }

    private void ResumeButtonPressed()
    {
        _resumeButton.clicked -= ResumeButtonPressed;
        _restartButton.clicked -= RestartButtonPressed;
        _exitGame.clicked -= ExitGame;
        _shieldButton.clicked -= ShieldButtonPressed;

        Time.timeScale = 1;
        _pauseLabel.style.display = DisplayStyle.None;
    }

    private void RestartButtonPressed()
    {
        _pauseButton.clicked -= PauseButtonPressed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
