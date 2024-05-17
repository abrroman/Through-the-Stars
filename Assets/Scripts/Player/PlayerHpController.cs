using System;
using System.Collections;
using UnityEngine;

public class PlayerHpController : MonoBehaviour {
    public const int MAX_HP = 50;
    public const float INVINCIBLE_TIME = 3.0f;

    [SerializeField]
    private int _hp;

    private bool _isHittable = true;

    public Action DamageTaken;
    public Action PlayerDied;

    public int Hp {
        get { return _hp; }
    }

    void Start() {
        _hp = MAX_HP;
    }

    public void TakeDamage(int damage) {
        if (!_isHittable) {
            return;
        }

        _hp -= damage;
        StartCoroutine(BecomeInvincible());
        DamageTaken?.Invoke();

        if (_hp <= 0) {
            Death();
        }
    }

    private void Death() {
        StartCoroutine(EndGame());
    }

    private IEnumerator BecomeInvincible() {
        _isHittable = false;
        yield return StartCoroutine(GetComponent<PlayerFlash>().FlashPlayer(INVINCIBLE_TIME));
        _isHittable = true;
    }

    private IEnumerator EndGame() {
        GetComponent<PlayerSoundController>().PlayDeathSound();
        GetComponent<ExplosionController>().StartExplosion();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
        PlayerDied?.Invoke();
    }
}