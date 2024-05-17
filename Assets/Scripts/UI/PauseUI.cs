using UnityEngine;
using UnityEngine.UIElements;

public class PauseUI : UIElement {
    public GameManager gameManager;

    private VisualElement _container;

    private Button _resumeButton;
    private Button _quitButton;

    private void OnEnable() {
        gameManager.GamePaused += OnGamePaused;
        gameManager.GameUnpaused += OnGameUnpaused;
    }

    private void OnDisable() {
        gameManager.GamePaused -= OnGamePaused;
        gameManager.GameUnpaused -= OnGameUnpaused;
    }

    void Start() {
        InitElements();
        _container.style.display = DisplayStyle.None;
    }

    private void InitElements() {
        _container = _root.Q<VisualElement>("Container");
        _resumeButton = _root.Q<Button>("ResumeButton");
        _quitButton = _root.Q<Button>("QuitButton");
        _resumeButton.RegisterCallback<ClickEvent>(OnResumeButtonClicked);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);
    }

    private void OnGamePaused() {
        _container.style.display = DisplayStyle.Flex;
    }

    private void OnGameUnpaused() {
        UnityEngine.Cursor.visible = false;
        _container.style.display = DisplayStyle.None;
    }

    private void OnResumeButtonClicked(ClickEvent evnt) {
        UnityEngine.Cursor.visible = false;
        gameManager.isPaused = false;
        Time.timeScale = 1.0f;
        _container.style.display = DisplayStyle.None;
    }

    private void OnQuitButtonClicked(ClickEvent evnt) {
        Application.Quit();
    }
}