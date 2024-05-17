using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Action GamePaused;
    public Action GameUnpaused;
    public PlayerHpController playerHpController;

    public bool isPaused = false;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip mainGameMusic;

    [SerializeField]
    private AudioClip gameOverMusic;

    private bool _isGameOver = false;

    private void OnEnable() {
        playerHpController.PlayerDied += OnPlayerDied;
        if (!source) {
            source = GetComponent<AudioSource>();
        }
    }

    private void OnDisable() {
        playerHpController.PlayerDied -= OnPlayerDied;
    }

    private void Start() {
        Cursor.visible = false;
        _isGameOver = false;
        Time.timeScale = 1.0f;
        source.clip = mainGameMusic;
        source.Play();
    }


    private void Update() {
        if (_isGameOver) {
            source.Stop();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Cursor.visible = false;
                Time.timeScale = 1.0f;
                isPaused = false;
                GameUnpaused?.Invoke();
            } else {
                Cursor.visible = true;
                isPaused = true;
                Time.timeScale = 0.0f;
                GamePaused?.Invoke();
            }
        }
    }

    private void OnPlayerDied() {
        Cursor.visible = true;
        _isGameOver = true;
    }
}