using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TorretaAttackStrategy : MonoBehaviour, IUnitStrategy
{
    private GameObject _currentUnit;
    private GameObject _enemy;
    private HealthController _enemyHealthController;
    private float _attackValue;
    private float _lastAttackTime;
    private float _attackCooldown;

    public TorretaAttackStrategy(GameObject currentUnit, GameObject enemy)
    {
        _currentUnit = currentUnit;
        _enemyHealthController = enemy.GetComponent<UnitScript>().healthController;
        _attackCooldown = enemy.GetComponent<UnitScript>().unitStats.RateFire;
        _lastAttackTime = Time.time - _attackCooldown;
        _enemy = enemy;
    }

    public string GetNameStrategy()
    {
        return "TorretaAttackStrategy";
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
            // Call the TakeDamage method of the enemy's HealthController
            _enemyHealthController.TakeDamage(_currentUnit.GetComponent<UnitScript>().unitStats.AttackValue);
        }
    }
}