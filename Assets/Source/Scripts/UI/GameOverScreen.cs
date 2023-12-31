using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    [SerializeField][Range(0, 1)] private float _backgroundAlpha;

    private CanvasGroup _gameOverGroup;

    private void Awake()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();

        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayerDied()
    {
        _gameOverGroup.alpha = _backgroundAlpha;
        _gameOverGroup.interactable = true;

        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
