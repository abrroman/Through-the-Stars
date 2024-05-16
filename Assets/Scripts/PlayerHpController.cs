using System.Collections;
using System.Collections.Generic;
using SmallShips;
using UnityEngine;

public class PlayerHpController : MonoBehaviour {
    private const int MAX_HP = 50;
    
    [SerializeField]
    private int _hp;
    private Animator _anim;
    
    public int Hp {
        get { return _hp; }
    }
    
    void Start() {
        _hp = MAX_HP;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        _hp -= damage;

        if (_hp <= 0) {
            Death();
        }
    }

    private void Death() {
        GetComponent<ExplosionController>().StartExplosion();
    }
}
