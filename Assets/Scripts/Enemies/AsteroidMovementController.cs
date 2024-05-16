using UnityEngine;

public class AsteroidMovementController : MonoBehaviour {
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float rotationSpeed = 40.0f;

    void Update() {
        transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}