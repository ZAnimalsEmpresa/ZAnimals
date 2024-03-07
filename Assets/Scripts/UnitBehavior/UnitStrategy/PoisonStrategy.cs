using UnityEditor;
using UnityEngine;

public class PoisonStrategy : IUnitStrategy
{
    private HealthController _enemyHealthController;
    private HealthBarScript _healthBarScript;
    private GameObject _currentUnit;
    private GameObject _enemy;
    private float _attackValue;
    private float _lastAttackTime;
    private float _attackCooldown;

    public PoisonStrategy(GameObject currentUnit, GameObject enemy)
    {
        _currentUnit = currentUnit;
        _enemyHealthController = enemy.GetComponent<UnitScript>().healthController; // Obtener el HealthController del enemigo
        _attackCooldown = enemy.GetComponent<UnitScript>().unitStats.RateFire;
        _lastAttackTime = Time.time - _attackCooldown; // Initialise to allow first attack
    }

    public void Execute()
    {
        PoisonAttack();
    }

    public string GetNameStrategy()
    {
        return "PoisonStrategy";
    }

    public void PoisonAttack()
    {
     _enemyHealthController.IsPoisoned = true;
    }
}