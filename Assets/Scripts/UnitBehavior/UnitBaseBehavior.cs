using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
public class UnitBaseBehavior
{
    // Private
    private UnitScript _unitScript;

    private GameObject _targetDestination;

    private UnitContext _unitContext;

    private GameObject _targetUnit;

    private NavMeshAgent _agent;

    private UnitAnimations _unitAnimations;

    private GameObject _bomb;

    public UnitBaseBehavior(UnitScript unitScript, Animator animator, NavMeshAgent navMeshAgent, GameObject bomb) 
    {
        _unitScript = unitScript;
        _targetDestination = GetTargetDestination();
        _agent = navMeshAgent;
        _unitAnimations = new UnitAnimations(animator);
        _unitContext = new UnitContext(new MoveStrategy(_agent, _targetDestination.transform), _unitAnimations);
        _bomb = bomb;
    }

    public void HandleBaseBehavior()
    {
        _unitContext.ExecuteStrategy();
    }

    public void StopAllBehaviors()
    {
        // Detener todos los comportamientos aquí

        // Por ejemplo, si estás utilizando un NavMeshAgent, podrías detenerlo así:
        if (_agent != null)
        {
            _agent.ResetPath(); // Detener el movimiento del NavMeshAgent
        }

        // Detener cualquier otro comportamiento que esté activo en tu juego
    }

    public void HandleEnterBehavior(GameObject other)
    {
        if (other.tag == GetCounterFaction() && _targetUnit == null)
        {
            _targetUnit = other;
            if (_unitScript.unitStats.IsBomber)
            {
                _unitContext.SetStrategy(new AttackBombStrategy(_unitScript.gameObject, _targetUnit, _bomb));
            }
            else
            {
                _unitContext.SetStrategy(new AttackStrategy(_unitScript.gameObject, _targetUnit));
            }
            
            _unitContext.StopCurrentStrategy(_agent, true);
            _unitContext.ExecuteStrategy();
            // Obtain the enemy's HealthController
            HealthController enemyHealthController = _targetUnit.GetComponent<UnitScript>().healthController;
            if (enemyHealthController != null)
            {
                // Subscribe to the OnUnitDeath event to detect when the enemy is destroyed
                enemyHealthController.OnUnitDeath += OnEnemyDeath;
            }
        }
        else if (other.gameObject.tag == "AllyBase" && _targetUnit == null)
        {
            _targetUnit = other;
            _unitContext.SetStrategy(new AttackBaseStrategy(_unitScript.gameObject, _targetUnit));
            _unitContext.StopCurrentStrategy(_agent, true);
            _unitContext.ExecuteStrategy();

            // Obtain the base HP Controller
            BaseHPController baseHPController = _targetUnit.GetComponent<BaseScript>().baseHPController;
            if (baseHPController != null)
            {
                // Subscribe to the OnUnitDeath event to detect when the enemy is destroyed
                baseHPController.OnBaseDestroy += OnBaseDestroy;
            }
        }
    }

    public void HandleExitBehavior(GameObject other)
    {
        if (other.gameObject.tag == GetCounterFaction() && other.gameObject == _targetUnit)
        {
            _targetUnit = null;
            _unitContext.StopCurrentStrategy(_agent, false);
            _unitContext.SetStrategy(new MoveStrategy(_agent, _targetDestination.transform));
            _unitContext.ExecuteStrategy();
            // Unsubscribe to the OnUnitDeath event if the enemy is no longer in contact
            HealthController enemyHealthController = other.gameObject.GetComponent<UnitScript>().healthController;
            if (enemyHealthController != null)
            {
                enemyHealthController.OnUnitDeath -= OnEnemyDeath;
            }
        }
        else if (other.gameObject.tag == "AllyBase" && other.gameObject == _targetUnit)
        {
            _targetUnit = null;
            _unitContext.StopCurrentStrategy(_agent, false);
            _unitContext.SetStrategy(new MoveStrategy(_agent, _targetDestination.transform));
            _unitContext.ExecuteStrategy();
            // Unsubscribe to the OnUnitDeath event if the enemy is no longer in contact
            BaseHPController baseHPController = other.gameObject.GetComponent<BaseScript>().baseHPController;
            if (baseHPController != null)
            {
                baseHPController.OnBaseDestroy -= OnBaseDestroy;
            }
        }
    }

    public void HandleDeathBehavior()
    {
        _unitContext.SetStrategy(new DeathSrategy(_agent, false));
        _unitContext.ExecuteStrategy();
    }
    private GameObject GetTargetDestination()
    {
        GameObject resDestination = null;
        if (UnitFaction.Ally == _unitScript.unitStats.UnitFaction)
        {
            resDestination = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        else if(UnitFaction.Enemy == _unitScript.unitStats.UnitFaction)
        {
            resDestination = GameObject.FindGameObjectWithTag("AllyBase");
        }
        return resDestination;
    }
    private string GetCounterFaction()
    {
        string resCounterFaction = "";
        if (UnitFaction.Ally == _unitScript.unitStats.UnitFaction)
        {
            resCounterFaction = "Enemy";
        }
        else if (UnitFaction.Enemy == _unitScript.unitStats.UnitFaction)
        {
            resCounterFaction = "Ally";
        }
        return resCounterFaction;
    }

    public void OnEnemyDeath()
    {
        // Unsubscribe to OnUnitDeath event
        HealthController enemyHealthController = _targetUnit.GetComponent<UnitScript>().healthController;
        if (enemyHealthController != null)        {

            enemyHealthController.OnUnitDeath -= OnEnemyDeath;
            _targetUnit = null;
        }

        // Check if there is another enemy in range
        Collider[] hitColliders = Physics.OverlapSphere(_unitScript.transform.position, 3);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != _unitScript.gameObject && hitCollider.CompareTag(GetCounterFaction()))
            {
                // Once another enemy in range is found, establish a new attack strategy.
                _targetUnit = hitCollider.gameObject;
                if (_unitScript.unitStats.IsBomber)
                {
                    _unitContext.SetStrategy(new AttackBombStrategy(_unitScript.gameObject, _targetUnit, _bomb));
                }
                else
                {
                    _unitContext.SetStrategy(new AttackStrategy(_unitScript.gameObject, _targetUnit));
                }

                // Subscribe to the OnUnitDeath event of the new enemy
                HealthController newEnemyHealthController = _targetUnit.GetComponent<UnitScript>().healthController;
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

    public void OnBaseDestroy()
    {
        // Unsubscribe to OnUnitDeath event
        BaseHPController baseHPController = _targetUnit.GetComponent<BaseScript>().baseHPController;
        if (baseHPController != null)
        {
            baseHPController.OnBaseDestroy -= OnBaseDestroy;
            _targetUnit = null;
        }

        // Check if there is another enemy in range
        Collider[] hitColliders = Physics.OverlapSphere(_unitScript.transform.position, 3);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != _unitScript.gameObject && hitCollider.CompareTag(GetCounterFaction()))
            {
                // Once another enemy in range is found, establish a new attack strategy.
                _targetUnit = hitCollider.gameObject;
                if (_unitScript.unitStats.IsBomber)
                {
                    _unitContext.SetStrategy(new AttackBombStrategy(_unitScript.gameObject, _targetUnit, _bomb));
                }
                else
                {
                    _unitContext.SetStrategy(new AttackStrategy(_unitScript.gameObject, _targetUnit));
                }

                // Subscribe to the OnUnitDeath event of the new enemy
                HealthController newEnemyHealthController = _targetUnit.GetComponent<UnitScript>().healthController;
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

    public string GetNameContext()
    {
        return _unitContext.GetNameStrategy();
    }

    public GameObject TargetUnit { get => _targetUnit; set => _targetUnit = value; }
}
