using UnityEngine;

public class DestroyOffBottomScreen : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("BottomBorder")) {
            Destroy(gameObject);
        }
    }
}