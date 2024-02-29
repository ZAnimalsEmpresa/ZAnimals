using UnityEditor;
using UnityEngine;

public class AttackStrategy : IUnitStrategy
{
    private GameObject _currentUnit;
    private GameObject _enemy;
    private HealthController _enemyHealthController;
    private float _lastAttackTime;
    private float _attackCooldown;

    public AttackStrategy(GameObject currentUnit,GameObject enemy, float attackCooldown)
    {
        _currentUnit = currentUnit;
        _enemy = enemy;
        _enemyHealthController = enemy.GetComponent<HealthController>(); // Obtener el HealthController del enemigo
        _attackCooldown = attackCooldown;
        _lastAttackTime = Time.time - attackCooldown; // Initialise to allow first attack
    }

    public string GetNameStrategy()
    {
        return "AttackStrategy";
    }

    public void Execute()
    {
        // Get the current time
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

    private void DealDamage()
    {
        if (_enemyHealthController != null)
        {
            // Llamar al método TakeDamage del HealthController del enemigo
            _enemyHealthController.TakeDamage(_currentUnit.GetComponent<UnitStats>().attackValue);            
        }
    }
}
