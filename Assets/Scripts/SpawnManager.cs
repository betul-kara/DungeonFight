using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float spawnInterval;
    [SerializeField] List<BoxCollider> spawnAreas;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (Player.Instance != null && Player.Instance.isSpawned)
        {
            BoxCollider spawnArea = spawnAreas[LevelManager.Instance.level];

            float random_x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float random_y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            float random_z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Vector3 spawnPoint = new(random_x, random_y, random_z);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPoint, Quaternion.identity);
        }
    }
}
