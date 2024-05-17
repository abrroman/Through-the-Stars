using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    [SerializeField]
    private float scrollSpeed = 1.0f;

    [SerializeField]
    private PlayerController playerController;

    private float _topBorder;
    private float _bottomBorder;
    private Vector3 _distanceBetweenBorders;

    void Start() {
        GetBorders();
        _distanceBetweenBorders = new Vector3(0.0f, _topBorder - _bottomBorder, 0.0f);
    }

    void Update() {
        if (!playerController) {
            scrollSpeed = 5.0f;
        } else {
            scrollSpeed = playerController.CurrentSpeed - 4.0f;
        }

        transform.localPosition += Vector3.down * (scrollSpeed * Time.deltaTime);

        if (IsPassedBorder()) {
            Loop();
        }
    }

    private void GetBorders() {
        var sprite = GetComponent<SpriteRenderer>();
        _topBorder = transform.position.y + sprite.bounds.extents.y / 3.0f;
        _bottomBorder = transform.position.y - sprite.bounds.extents.y / 3.0f;
    }

    private bool IsPassedBorder() {
        if (scrollSpeed > 0.0f && transform.position.y < _bottomBorder
            || scrollSpeed < 0.0f && transform.position.y > _topBorder) {
            return true;
        }

        return false;
    }

    private void Loop() {
        if (scrollSpeed > 0.0f) {
            transform.position += _distanceBetweenBorders;
        } else {
            transform.position -= _distanceBetweenBorders;
        }
    }
}