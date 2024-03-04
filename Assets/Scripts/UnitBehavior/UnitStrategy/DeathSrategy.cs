using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathSrategy : IUnitStrategy
{
    private NavMeshAgent _navMeshAgent;
    private bool _isRunning;
    public DeathSrategy(NavMeshAgent navMeshAgent, bool isRunning)
    {
        _navMeshAgent = navMeshAgent;
        _isRunning = isRunning;
    }
    public void Execute()
    {
        _navMeshAgent.isStopped = _isRunning;
    }

    public string GetNameStrategy()
    {
        return "DeathStrategy";
    }

}
