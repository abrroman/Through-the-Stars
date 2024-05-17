using UnityEngine;

public class BaseBulletStarter : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletStartPos;

    public int bulletSortingOrder = 0;

    [SerializeField]
    private float bulletSpeed = 20.0f;

    public void MakeShot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletStartPos.position, Quaternion.identity);
        if (bulletSortingOrder != 0) {
            bullet.GetComponent<SpriteRenderer>().sortingOrder = bulletSortingOrder;
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpeed * (-bulletStartPos.up);
    }
}