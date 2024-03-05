using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
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
            BoxCollider spawnArea = spawnAreas[GameManager.level - 1];

            Vector3 spawnPoint = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
