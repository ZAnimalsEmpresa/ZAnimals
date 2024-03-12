using UnityEditor;
using UnityEngine;

public class AttackBaseStrategy : IUnitStrategy
{
    private GameObject _currentUnit;
    private GameObject _enemyBase;
    private BaseHPController _baseHPController;
    private float _lastAttackTime;
    private float _attackCooldown;

    public AttackBaseStrategy(GameObject currentUnit, GameObject enemyBase)
    {
        _currentUnit = currentUnit;
        _baseHPController = enemyBase.GetComponent<BaseScript>().baseHPController; // Obtener el HPController de la base
        _attackCooldown = 50f;
        _lastAttackTime = Time.time - _attackCooldown; // Initialise to allow first attack
    }

    public string GetNameStrategy()
    {
        return "AttackBaseStrategy";
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
        }
    }

    private void DealDamage()
    {
        if (_baseHPController != null)
        {
            // Llamar al método TakeDamage del BaseHPController
            _baseHPController.TakeDamage(_currentUnit.GetComponent<UnitScript>().unitStats.AttackValue);
        }
    }
}
