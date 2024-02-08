using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemyRandomFactory enemyFactory; // Referencia al EnemyRandomFactory
    public float timeBetweenWaves = 5f; // Tiempo entre oleadas
    public int numberOfWaves = 3; // N�mero total de oleadas
    public int enemiesPerWave = 5; // N�mero de enemigos por oleada
    public Transform spawnPosition;

    public Vector3 spawnCubeSize = new Vector3(10f, 1f, 10f); // Tama�o del cubo de spawneo


    private void Start()
    {
        // Comenzar la generaci�n de oleadas
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

            // Configurar la posici�n de los enemigos seg�n sea necesario
            // Por ejemplo, podr�as establecer posiciones aleatorias o posiciones predefinidas
            enemy.transform.position = GetRandomSpawnCubePosition();
        }
    }

    private Vector3 GetRandomSpawnCubePosition()
    {
        // Generar posici�n aleatoria dentro del cubo de spawneo
        return new Vector3(
            Random.Range(transform.position.x - spawnCubeSize.x / 2, transform.position.x + spawnCubeSize.x / 2),
            transform.position.y + spawnCubeSize.y / 2,
            Random.Range(transform.position.z - spawnCubeSize.z / 2, transform.position.z + spawnCubeSize.z / 2));
    }

    // M�todo para obtener una posici�n de generaci�n aleatoria (puedes personalizar seg�n tu escenario)
    private Vector3 GetRandomSpawnPosition()
    {
        // Por ejemplo, puedes usar Random.Range para obtener una posici�n aleatoria dentro de un �rea predefinida
        return new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
    }
}
