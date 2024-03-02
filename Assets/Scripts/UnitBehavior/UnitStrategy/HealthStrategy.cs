using UnityEditor;
using UnityEngine;

public class HealthStrategy : IUnitStrategy
{
    private HealthController _enemyHealthController;

    public HealthStrategy(GameObject currentUnit, GameObject enemy, float attackCooldown)
    {
        _enemyHealthController = enemy.GetComponent<HealthController>(); // Obtener el HealthController del enemigo
    }

    public void Execute()
    {
            DealDamage();
    }

    private void DealDamage()
    {
        if (_enemyHealthController == true)
        {
           // Curar cada vez que golpea
            _enemyHealthController.isPoisoned = false;
        }
    }
}