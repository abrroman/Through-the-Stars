using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenuUI : UIElement {
    private VisualElement _container;

    private Button _playButton;
    private Button _quitButton;

    void Start() {
        InitElements();
    }

    private void InitElements() {
        _playButton = _root.Q<Button>("PlayButton");
        _quitButton = _root.Q<Button>("QuitButton");
        _playButton.RegisterCallback<ClickEvent>(OnPlayButtonClicked);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);
    }


    private void OnPlayButtonClicked(ClickEvent evnt) {
        SceneManager.LoadScene("MainGame");
    }

    private void OnQuitButtonClicked(ClickEvent evnt) {
        Application.Quit();
    }
}