using UnityEditor;
using UnityEngine;

public class PoisonStrategy : IUnitStrategy
{
    private HealthController _enemyHealthController;

    public PoisonStrategy(GameObject currentUnit, GameObject enemy, float attackCooldown)
    {
        _enemyHealthController = enemy.GetComponent<HealthController>(); // Obtener el HealthController del enemigo
    }

    public void Execute()
    {
            DealDamage();
    }

    private void DealDamage()
    {
        if (_enemyHealthController != null)
        {
           // Envenenar al enemigo cada vez que se le golpea
            _enemyHealthController.isPoisoned = true;
        }
    }
}