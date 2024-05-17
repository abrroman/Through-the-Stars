using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : UIElement {
    public PlayerHpController hpController;

    private VisualElement _container;

    private Button _restartButton;
    private Button _quitButton;

    private void OnEnable() {
        hpController.PlayerDied += OnPlayerDied;
    }

    private void OnDisable() {
        hpController.PlayerDied -= OnPlayerDied;
    }

    void Start() {
        InitElements();
        _container.style.display = DisplayStyle.None;
    }

    private void InitElements() {
        _container = _root.Q<VisualElement>("Container");
        _restartButton = _root.Q<Button>("RestartButton");
        _quitButton = _root.Q<Button>("QuitButton");
        _restartButton.RegisterCallback<ClickEvent>(OnRestartButtonClicked);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);
    }

    private void OnPlayerDied() {
        _container.style.display = DisplayStyle.Flex;
    }

    private void OnRestartButtonClicked(ClickEvent evnt) {
        SceneManager.LoadScene("MainGame");
    }

    private void OnQuitButtonClicked(ClickEvent evnt) {
        Application.Quit();
    }
}