using System;
using System.Collections;
using SmallShips;
using UnityEngine;

public class PlayerHpController : MonoBehaviour {
    public const int MAX_HP = 50;
    public const float INVINCIBLE_TIME = 3.0f;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private Color flashColor;

    [SerializeField]
    private int _hp;

    private Animator _anim;
    private bool _isHittable = true;

    public Action DamageTaken;

    private void OnValidate() {
        if (!sprite) {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    public int Hp {
        get { return _hp; }
    }

    void Start() {
        _hp = MAX_HP;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        if (!_isHittable) {
            return;
        }

        _hp -= damage;
        StartCoroutine(BecomeInvincible());
        StartCoroutine(FlashPlayer());
        DamageTaken?.Invoke();

        if (_hp <= 0) {
            Death();
        }
    }

    private void Death() {
        GetComponent<ExplosionController>().StartExplosion();
    }

    private IEnumerator BecomeInvincible() {
        _isHittable = false;
        yield return StartCoroutine(FlashPlayer());
        _isHittable = true;
    }

    private IEnumerator FlashPlayer() {
        Color originalColor = sprite.color;
        float elapsedTime = 0.0f;
        float elapsedFlashPercentage = 0.0f;
        float pingPongPercentage;

        while (elapsedTime < INVINCIBLE_TIME) {
            elapsedTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedTime / INVINCIBLE_TIME;

            if (elapsedFlashPercentage > 1.0f) {
                elapsedFlashPercentage = 1.0f;
            }


            pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * 6, 1);
            sprite.color = Color.Lerp(originalColor, flashColor, pingPongPercentage);

            yield return null;
        }
    }
}