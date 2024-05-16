using UnityEngine;

public class EnemyProjectileHazard : MonoBehaviour {
    private int _damage = 10;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerHpController>().TakeDamage(_damage);
        }

        if (GetComponent<EnemyShot>() != null && other.GetComponent<EnemyShip>() == null) {
            Destroy(gameObject);
        }
    }
}