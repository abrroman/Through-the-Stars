using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHazard : MonoBehaviour {

    private int _damage = 25;
    void Start() {
    }

    void Update() {
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerHpController>().TakeDamage(_damage);
        }
    }
}