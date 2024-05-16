using UnityEngine;

public class Statistic : MonoBehaviour {
    private int _score = 0;
    private float _elapsedTime = 0.0f;

    public float Score {
        get { return _score; }
    }

    void Start() {
        _score = 0;
    }
    
    void Update() {
        _elapsedTime += Time.deltaTime;
        _score = Mathf.FloorToInt(_elapsedTime);
    }
}
