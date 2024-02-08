using UnityEditor;
using UnityEngine;

public class AttackStrategy : IUnitStrategy
{
    private GameObject _enemy;
    private float _lastAttackTime;
    private float _attackCooldown;

    public AttackStrategy(GameObject enemy, float attackCooldown)
    {
        _enemy = enemy;
        _attackCooldown = attackCooldown;
        _lastAttackTime = Time.time - attackCooldown; // Initialise to allow first attack

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
            Debug.Log("Funsionaaaa!!!!!!!!!" + currentTime);
            _lastAttackTime = Time.time;
        }
    }
}
