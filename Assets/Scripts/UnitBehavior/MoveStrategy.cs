using UnityEngine;
using UnityEngine.AI;

public class MoveStrategy : IUnitStrategy
{
    
    private NavMeshAgent _navMeshAgent;
    private Transform _destination;

    public MoveStrategy(NavMeshAgent navMeshAgent, Transform destination)
    {
        _navMeshAgent = navMeshAgent;
        _destination = destination;
    }

    public void Execute()
    {
        if (_navMeshAgent != null && _destination != null)
        {
            _navMeshAgent.SetDestination(_destination.position);
        }
    }

}
