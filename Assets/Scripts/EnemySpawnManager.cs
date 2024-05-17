using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour {
    [SerializeField]
    private Statistic stats;

    [SerializeField]
    private GameObject[] enemies;

    private float _spawnZoneWidth;

    private float _spawnZoneHeight = 5.0f;
    private Vector2 _cameraMax;

    private void Start() {
        GetCameraViewBounds();
        _spawnZoneWidth = _cameraMax.x;
        InvokeRepeating(nameof(SpawnEnemyFromPool), 2.0f, 1.0f);
    }

    private void GetCameraViewBounds() {
        _cameraMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
    }

    private void SpawnEnemyFromPool() {
        int enemyIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnZoneWidth, _spawnZoneWidth), Random.Range(_cameraMax.y, _cameraMax.y + _spawnZoneHeight), 0);
        var enemyClone = Instantiate(enemies[enemyIndex], spawnPos, Quaternion.identity);
        enemyClone.GetComponent<EnemyHpController>().stats = stats;
    }
}