using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static float spawnInterval = 5f;
    [SerializeField] BoxCollider[] spawnAreas;
    [SerializeField] GameObject[] enemyPrefabs;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (Player.Instance != null && Player.Instance.isSpawned)
        {
            BoxCollider spawnArea = spawnAreas[LevelManager.Level];

            float random_x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            float random_y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            float random_z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Vector3 spawnPoint = new(random_x, random_y, random_z);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPoint, Quaternion.identity);
        }
    }
}
