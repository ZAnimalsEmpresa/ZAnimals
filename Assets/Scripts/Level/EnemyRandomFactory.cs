using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array containing enemy prefabs

    public GameObject CreateEnemy()
    {
        // Generate a random index to select an enemy prefab
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Instantiate and return a new enemy using the selected prefab
        return Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
