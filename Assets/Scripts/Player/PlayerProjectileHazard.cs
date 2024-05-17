using UnityEngine;

public class PlayerProjectileHazard : MonoBehaviour {
    
    [SerializeField]
    private int damage = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyHpController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}