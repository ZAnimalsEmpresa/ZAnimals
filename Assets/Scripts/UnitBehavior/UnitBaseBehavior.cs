using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitBaseBehavior : MonoBehaviour
{
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
        _targetDestination = GameObject.FindGameObjectWithTag("EnemyBase");
        _unitContext = new UnitContext(new MoveStrategy(_agent, _targetDestination.transform));
    }

    void Update()
    {
        _unitContext.ExecuteStrategy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _targetUnit = other.gameObject;
            _unitContext.SetStrategy(new AttackStrategy(_targetUnit, 0.5f));
            _unitContext.StopCurrentStrategy(_agent,true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _targetUnit = null;
            _unitContext.StopCurrentStrategy(_agent, false);
            _unitContext.SetStrategy(new MoveStrategy(_agent, _targetDestination.transform));
        }
    }
}
