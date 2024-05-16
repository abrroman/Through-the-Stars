using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundScroll : MonoBehaviour {
    [SerializeField]
    private float scrollSpeed = 1.0f;

    private float _topBorder;
    private float _bottomBorder;
    private Vector3 _distanceBetweenBorders;

    void Start() {
        GetBorders();
        _distanceBetweenBorders = new Vector3(0.0f, _topBorder - _bottomBorder, 0.0f);
    }

    void Update() {
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