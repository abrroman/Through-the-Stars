using UnityEngine.UIElements;

public class ScoreLabel : UIElement {
    public Statistic stats;
    private Label _scoreLabel;

    void Start() {
        _scoreLabel = _root.Q<Label>("ScoreAmount");
    }

    void Update() {
        _scoreLabel.text = $"{stats.Score:0000}";
    }
}