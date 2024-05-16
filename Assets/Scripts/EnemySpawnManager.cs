using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] Enemies;

    private float _spawnZoneWidth;

    private float _spawnZoneHeight = 5.0f;
    private Vector2 _cameraMax;
    private Vector2 _cameraMin;

    private void Start() {
        GetCameraViewBounds();
        _spawnZoneWidth = _cameraMax.x;
        InvokeRepeating(nameof(SpawnEnemyFromPool), 2.0f, 3.0f);
    }

    private void GetCameraViewBounds() {
        _cameraMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        _cameraMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
    }

    private void SpawnEnemyFromPool() {
        int enemyIndex = Random.Range(0, Enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnZoneWidth, _spawnZoneWidth), Random.Range(_cameraMax.y, _cameraMax.y + _spawnZoneHeight), 0);
        Instantiate(Enemies[enemyIndex], spawnPos, Quaternion.identity);
    }
}