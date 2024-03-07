using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBombStrategy : IUnitStrategy
{
    private GameObject _currentUnit;
    private GameObject _enemy;
    private HealthController _enemyHealthController;
    public GameObject bomberSphere;
    private float _attackValue;
    private float _lastAttackTime;
    private float _attackCooldown;

    public AttackBombStrategy(GameObject currentUnit, GameObject enemy, GameObject bomberSphere)
    {
        _currentUnit = currentUnit;
        _enemy = enemy;
        _enemyHealthController = enemy.GetComponent<UnitScript>().healthController; // Obtener el HealthController del enemigo
        _attackCooldown = enemy.GetComponent<UnitScript>().unitStats.RateFire;
        _lastAttackTime = Time.time - _attackCooldown; // Initialise to allow first attack
        this.bomberSphere = bomberSphere;
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
            ShootAtTarget();
            _lastAttackTime = Time.time;
        }
    }

    public string GetNameStrategy()
    {
        return "AttackBombStrategy";
    }

    //private void FindTarget()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(_currentUnit.transform.position, _currentUnit.GetComponent<UnitScript>().unitStats.RangeAttack);

    //    foreach (var collider in colliders)
    //    {
    //        if (collider.CompareTag("Enemy"))
    //        {
    //            target = collider.transform;
    //            ShootAtTarget();
    //            break;
    //        }
    //    }
    //}

    private void ShootAtTarget()
    {
            Vector3 launchDirection = (_enemy.transform.position - _currentUnit.transform.position).normalized;
            GameObject newSphere = GameObject.Instantiate(bomberSphere, _currentUnit.transform.position + launchDirection, Quaternion.identity);
            Rigidbody rb = newSphere.GetComponent<Rigidbody>();
            rb.velocity = launchDirection * 10f;
    }
}
