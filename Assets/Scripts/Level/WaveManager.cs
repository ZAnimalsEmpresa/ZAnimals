using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemyRandomFactory enemyFactory; // Referencia al EnemyRandomFactory
    public float timeBetweenWaves = 5f; // Tiempo entre oleadas
    public int numberOfWaves = 3; // Número total de oleadas
    public int enemiesPerWave = 5; // Número de enemigos por oleada
    public Transform spawnPosition;

    public Vector3 spawnCubeSize = new Vector3(10f, 1f, 10f); // Tamaño del cubo de spawneo


    private void Start()
    {
        // Comenzar la generación de oleadas
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < numberOfWaves; wave++)
        {
            // Esperar antes de iniciar la siguiente oleada
            yield return new WaitForSeconds(timeBetweenWaves);

            // Generar una oleada de enemigos
            SpawnEnemies(enemiesPerWave);
        }
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Utilizar el factory para crear un nuevo enemigo
            GameObject enemy = enemyFactory.CreateEnemy();

            // Configurar la posición de los enemigos según sea necesario
            // Por ejemplo, podrías establecer posiciones aleatorias o posiciones predefinidas
            enemy.transform.position = GetRandomSpawnCubePosition();
        }
    }

    private Vector3 GetRandomSpawnCubePosition()
    {
        // Generar posición aleatoria dentro del cubo de spawneo
        return new Vector3(
            Random.Range(transform.position.x - spawnCubeSize.x / 2, transform.position.x + spawnCubeSize.x / 2),
            transform.position.y + spawnCubeSize.y / 2,
            Random.Range(transform.position.z - spawnCubeSize.z / 2, transform.position.z + spawnCubeSize.z / 2));
    }

    // Método para obtener una posición de generación aleatoria (puedes personalizar según tu escenario)
    private Vector3 GetRandomSpawnPosition()
    {
        // Por ejemplo, puedes usar Random.Range para obtener una posición aleatoria dentro de un área predefinida
        return new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
    }
}
