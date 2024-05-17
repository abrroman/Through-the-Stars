using System;
using System.Collections;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {
    private float _speed = 5.0f;

    [SerializeField]
    private float rotationModifier = -90.0f;

    private Rigidbody2D _rb;

    private float _fireRate = 3.0f;

    private GameObject _player;

    private float _maxDistanceToPlayer = 3.0f;


    void Start() {
        _rb = this.GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Shooting());
    }

    void Update() {
        MoveToPlayer();
    }

    private void Shoot() {
        GetComponent<BaseBulletStarter>().MakeShot();
    }

    private void MoveToPlayer() {
        Vector3 vectorToPLayer = _player.transform.position - transform.position;
        float angle = (float)Math.Atan2(vectorToPLayer.y, vectorToPLayer.x) * Mathf.Rad2Deg - rotationModifier;
        _rb.rotation = angle;
        if (Vector3.Distance(transform.position, _player.transform.position) > _maxDistanceToPlayer) {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
    }

    private IEnumerator Shooting() {
        while (gameObject) {
            yield return new WaitForSeconds(_fireRate);
            Shoot();
            GetComponent<EnemySoundController>().PlayShotSound();
        }
    }
}