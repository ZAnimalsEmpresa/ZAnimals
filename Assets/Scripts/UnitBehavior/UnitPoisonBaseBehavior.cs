using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(UnitStats))]
public class UnitPoisonBaseBehavior : MonoBehaviour
{
    [SerializeField]
    private UnitStats _unitStats;
    [SerializeField]
    private GameObject _targetDestination;
    [SerializeField]
    private UnitContext _unitContext;
    [SerializeField]
    private GameObject _targetUnit;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _targetDestination = GetTargetDestination();
        _unitContext = new UnitContext(new MoveStrategy(_agent, _targetDestination.transform));
    }

    void Update()
    {
        _unitContext.ExecuteStrategy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GetCounterFaction() && _targetUnit == null)
        {
            _targetUnit = other.gameObject;
            _unitContext.SetStrategy(new PoisonStrategy(this.gameObject,_targetUnit, 0.5f));
            _unitContext.StopCurrentStrategy(_agent,true);
            // Obtain the enemy's HealthController
            HealthController enemyHealthController = _targetUnit.GetComponent<HealthController>();
            if (enemyHealthController != null)
            {
                // Subscribe to the OnUnitDeath event to detect when the enemy is destroyed
                enemyHealthController.OnUnitDeath += OnEnemyDeath;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == GetCounterFaction() && other.gameObject == _targetUnit)
        {
            _targetUnit = null;
            _unitContext.StopCurrentStrategy(_agent, false);
            _unitContext.SetStrategy(new MoveStrategy(_agent, _targetDestination.transform));
        }
        // Unsubscribe to the OnUnitDeath event if the enemy is no longer in contact
        HealthController enemyHealthController = other.gameObject.GetComponent<HealthController>();
        if (enemyHealthController != null)
        {
            enemyHealthController.OnUnitDeath -= OnEnemyDeath;
        }
    }

    private GameObject GetTargetDestination()
    {
        GameObject resDestination = null;
        if (unitFaction.Ally == _unitStats.unitFaction)
        {
            resDestination = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        else if(unitFaction.Enemy == _unitStats.unitFaction)
        {
            resDestination = GameObject.FindGameObjectWithTag("AllyBase");
        }
        return resDestination;
    }

    private string GetCounterFaction()
    {
        string resCounterFaction = "";
        if (unitFaction.Ally == _unitStats.unitFaction)
        {
            resCounterFaction = "Enemy";
        }
        else if (unitFaction.Enemy == _unitStats.unitFaction)
        {
            resCounterFaction = "Ally";
        }
        return resCounterFaction;
    }


    private void OnEnemyDeath()
    {
        // Unsubscribe to OnUnitDeath event
        HealthController enemyHealthController = _targetUnit.GetComponent<HealthController>();
        if (enemyHealthController != null)
        {
            enemyHealthController.OnUnitDeath -= OnEnemyDeath;
            _targetUnit = null;
        }

        // Check if there is another enemy in range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _unitStats.rangeAttack);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject && hitCollider.CompareTag(GetCounterFaction()))
            {
                // Once another enemy in range is found, establish a new attack strategy.
                _targetUnit = hitCollider.gameObject;
                _unitContext.SetStrategy(new PoisonStrategy(gameObject, _targetUnit, 0.5f));

                // Subscribe to the OnUnitDeath event of the new enemy
                HealthController newEnemyHealthController = _targetUnit.GetComponent<HealthController>();
                if (newEnemyHealthController != null)
                {
                    newEnemyHealthController.OnUnitDeath += OnEnemyDeath;
                }

                // Stop the search for more enemies
                break;
            }
        }

        // Switching to movement strategy when the enemy is destroyed
        _unitContext.StopCurrentStrategy(_agent, false);
        _unitContext.SetStrategy(new MoveStrategy(_agent, _targetDestination.transform));
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento OnUnitDeath si está suscrito
        if (_targetUnit != null)
        {
            HealthController enemyHealthController = _targetUnit.GetComponent<HealthController>();
            if (enemyHealthController != null)
            {
                enemyHealthController.OnUnitDeath -= OnEnemyDeath;
            }
        }
    }
}
