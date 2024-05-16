using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float defaultSpeed = 10.0f;
    
    [SerializeField]
    private float boostSpeed = 15.0f;

    private float _currentSpeed;
    private Vector2 _max;
    private Vector2 _min;

    public float CurrentSpeed {
        get { return _currentSpeed;}
    }
    void Start() {
        _max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        _min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
    }
    
    void Update() {
        Move();
    }

    private void Move() {
        if (IsBoosting()) {
            _currentSpeed = boostSpeed;
        } else {
            _currentSpeed = defaultSpeed;
        }
        if (Input.GetAxisRaw("Horizontal") > 0.0f) {
            transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.right, _currentSpeed * Time.deltaTime);
        } 
        if (Input.GetAxisRaw("Horizontal") < 0.0f) {
            transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.left, _currentSpeed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0.0f) {
            transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.up, _currentSpeed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0.0f) {
            transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.down, _currentSpeed * Time.deltaTime);
        }
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _min.x + 1, _max.x - 1),
            Mathf.Clamp(transform.position.y, _min.y + 1, _max.y - 1));
    }
    
    private bool IsBoosting() {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
