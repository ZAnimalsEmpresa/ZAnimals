using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class UnitScript : MonoBehaviour
{

    [SerializeField]
    private UnitSO unit;

    public UnitStats unitStats;
    [HideInInspector]
    public HealthController healthController;
    [SerializeField]
    private UnitComponents _unitComponents;
    
    private UnitBaseBehavior _unitBaseBehavior;

    private void Awake()
    {
        unitStats = new UnitStats(unit, unitStats.IsBomber);
        healthController = new HealthController(this);
        _unitBaseBehavior = new UnitBaseBehavior(this,_unitComponents.Animator,_unitComponents.Agent,_unitComponents.Bomb);
        healthController.OnUnitDeath += HandleDeathStateChanged;
    }
    // Start is called before the first frame update
    void Start()
    {
        _unitBaseBehavior.HandleBaseBehavior();
    }
    // Update is called once per frame
    void Update()
    {
        if (_unitBaseBehavior.GetNameContext() != "DeathStrategy")
        {
            _unitBaseBehavior.HandleBaseBehavior();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_unitBaseBehavior.GetNameContext() != "DeathStrategy")
        {
            _unitBaseBehavior.HandleEnterBehavior(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_unitBaseBehavior.GetNameContext() != "DeathStrategy")
        {
            _unitBaseBehavior.HandleExitBehavior(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento OnUnitDeath si está suscrito
        if (_unitBaseBehavior.TargetUnit != null)
        {
            HealthController enemyHealthController = _unitBaseBehavior.TargetUnit.GetComponent<UnitScript>().healthController;
            if (enemyHealthController != null)
            {
                enemyHealthController.OnUnitDeath -= _unitBaseBehavior.OnEnemyDeath;
            }
        }
    }
    public void HandleDeathStateChanged()
    {
        _unitBaseBehavior.HandleDeathBehavior();
        // Lógica para manejar el cambio al estado de muerte
        healthController.OnUnitDeath -= HandleDeathStateChanged;
        _unitBaseBehavior.StopAllBehaviors();
    }
}
