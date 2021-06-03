using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject powerupPrefab;

    private float zEnemySpawn = 12;
    private float zPowerupSpawn = 5;
    private float xSpawnRange = 10;
    private float yEnemySpawn = 0.75f;

    private float powerupSpawnTime = 10;
    private float enemySpawnTime = 1.5f;
    private float startDelay = 1;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        Vector3 spawnPosition = new Vector3(randomX, yEnemySpawn, zEnemySpawn);

        Instantiate(enemyPrefabs[randomIndex], spawnPosition, enemyPrefabs[randomIndex].transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupSpawn, zPowerupSpawn);

        Vector3 spawnPosition = new Vector3(randomX, yEnemySpawn, randomZ);

        Instantiate(powerupPrefab, spawnPosition, powerupPrefab.transform.rotation);
    }
}
