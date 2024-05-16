using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmallShips {
    public class BaseBulletStarter : MonoBehaviour {
        public GameObject bulletPrefab;
        public Transform bulletStartPos;

        [Tooltip("If 0 than new sortingOrder will implemented for bullet")]
        public int bulletSortingOrder = 0;

        [SerializeField]
        private float bulletSpeed = 20.0f;

        [Space(20)]
        public GameObject bombPrefab;

        public Transform bombStartPos;
        public float bombSpeed;
        
        public void MakeShot() {
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPos.position, Quaternion.identity);
            if (bulletSortingOrder != 0) {
                bullet.GetComponent<SpriteRenderer>().sortingOrder = bulletSortingOrder;
            }

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bulletSpeed * (-bulletStartPos.up);
        }

        public void LaunchBomb() {
            GameObject bomb = (GameObject)Instantiate(bombPrefab, bombStartPos.position, bombStartPos.rotation);
            Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
            rb.velocity = bombSpeed * (-transform.up);
        }
    }
}