using UnityEngine;

public class PoisonStrategy : IUnitStrategy
{
    private HealthController _enemyHealthController;
    private GameObject _currentUnit;
    private GameObject _enemy;
    private float _attackValue;
    private float _lastAttackTime;
    private float _attackCooldown;

    public PoisonStrategy(GameObject currentUnit, GameObject enemy, float attackCooldown)
    {
        _currentUnit = currentUnit;
        _enemyHealthController = enemy.GetComponent<UnitScript>().healthController; // Obtener el HealthController del enemigo
        _attackCooldown = enemy.GetComponent<UnitScript>().unitStats.RateFire;
        _lastAttackTime = Time.time - _attackCooldown; // Initialise to allow first attack
    }

    public void Execute()
    {
        float currentTime = Time.time;

        // Calculate time elapsed since last attack
        float timeSinceLastAttack = currentTime - _lastAttackTime;

        if (timeSinceLastAttack >= _attackCooldown)
        {
            // Carry out attack only if sufficient time has passed since last attack.
            DealDamage();
            _lastAttackTime = Time.time;
        }
    }

    public string GetNameStrategy()
    {
        return "PoisonStrategy";
    }

    private void DealDamage()
    {
        if (_enemyHealthController != null)
        {
           // Envenenar al enemigo cada vez que se le golpea
            _enemyHealthController.IsPoisoned = true;
        }
    }
}