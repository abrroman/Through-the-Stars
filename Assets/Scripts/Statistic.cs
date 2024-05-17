using UnityEngine;

public class Statistic : MonoBehaviour {
    private int _score = 0;
    private float _elapsedTime = 0.0f;
    private int _timeScore = 0;
    private int _enemyScore = 0;


    public float Score {
        get { return _score; }
    }

    private void Start() {
        _score = 0;
    }

    private void Update() {
        _elapsedTime += Time.deltaTime;
        _timeScore = Mathf.FloorToInt(_elapsedTime);
        _score = _timeScore + _enemyScore;
    }

    public void AddScore(int score) {
        _enemyScore += score;
    }
}