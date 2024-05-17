using System.Collections;
using UnityEngine;

public class EnemyHpController : MonoBehaviour {
    public Statistic stats;

    private const int SHIP_MAX_HP = 20;
    private const int AST_MAX_HP = 25;

    [SerializeField]
    private int _hp;

    private bool _isShip;

    void Start() {
        if (GetComponent<Asteriod>() != null) {
            _hp = AST_MAX_HP;
            _isShip = false;
        } else if (GetComponent<EnemyShip>() != null) {
            _hp = SHIP_MAX_HP;
            _isShip = true;
        }
    }

    public void TakeDamage(int damage) {
        _hp -= damage;
        if (_hp <= 0) {
            Death();
        }
    }

    private void Death() {
        GetComponent<EnemySoundController>().PlayDeathSound();
        if (_isShip) {
            stats.AddScore(5);
            GetComponent<ExplosionController>().StartExplosion();
        } else {
            stats.AddScore(2);
            StartCoroutine(SafeDestroy());
        }
    }

    private IEnumerator SafeDestroy() {
        yield return new WaitUntil(() => !GetComponent<EnemySoundController>().source.isPlaying);
        Destroy(gameObject);
    }
}