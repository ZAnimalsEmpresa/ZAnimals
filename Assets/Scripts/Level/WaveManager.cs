using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemyRandomFactory enemyFactory; // Reference to EnemyRandomFactory
    public float timeBetweenWaves = 5f; 
    public int numberOfWaves = 3; 
    public int enemiesPerWave = 5;
    public Transform spawnPosition;
    public BoxCollider spawnSite;


    private Vector3 _spawnCubeSize = new Vector3(1f, 1f, 1f); // Size of spawning cube


    private void Start()
    {

        _spawnCubeSize = spawnSite.size;
        // Start wave generation
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < numberOfWaves; wave++)
        {
            // Wait before starting the next wave
            yield return new WaitForSeconds(timeBetweenWaves);

            // Generate a wave of enemies
            SpawnEnemies(enemiesPerWave);
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Use the factory to create a new enemy
            GameObject enemy = enemyFactory.CreateEnemy();

            // Configure the position of enemies as required
            enemy.transform.position = GetRandomSpawnCubePosition();
        }
    }

    private Vector3 GetRandomSpawnCubePosition()
    {
        // Generate random position within the spawning cube
        return new Vector3(
            Random.Range(transform.position.x - _spawnCubeSize.x / 2, transform.position.x + _spawnCubeSize.x / 2),
            transform.position.y + _spawnCubeSize.y / 2,
            Random.Range(transform.position.z - _spawnCubeSize.z / 2, transform.position.z + _spawnCubeSize.z / 2));
    }

    // Method for obtaining a randomly generated position 
    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
    }
}
