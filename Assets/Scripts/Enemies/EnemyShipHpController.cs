using System.Collections;
using System.Collections.Generic;
using SmallShips;
using UnityEngine;

public class EnemyHpController : MonoBehaviour {
    
    private const int SHIP_MAX_HP = 20;
    private const int AST_MAX_HP = 25;

    [SerializeField]
    private int _hp;

    private Animator _anim;

    private bool _isShip;

    public int Hp {
        get { return _hp; }
    }

    void Start() {
        if (GetComponent<Asteriod>() != null) {
            _hp = AST_MAX_HP;
            _isShip = false;
        } else if (GetComponent<EnemyShip>() != null) {
            _hp = SHIP_MAX_HP;
            _isShip = true;
        }
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        _hp -= damage;

        if (_hp <= 0) {
            Death();
        }
    }

    private void Death() {
        if (_isShip) {
            GetComponent<ExplosionController>().StartExplosion();
        } else {
            Destroy(gameObject);
        }
    }
}