using UnityEditor;
using UnityEngine;

public class HealthStrategy : IUnitStrategy
{
    private HealthController _enemyHealthController;

    public HealthStrategy(GameObject currentUnit, GameObject enemy)
    {
        _enemyHealthController = enemy.GetComponent<HealthController>(); // Obtener el HealthController del enemigo
    }

    public void Execute()
    {
        PoisonHealth();
    }

    public string GetNameStrategy()
    {
        return "HealthStrategy";
    }

    public void PoisonHealth()
    {
        _enemyHealthController.IsPoisoned = false;
    }
}