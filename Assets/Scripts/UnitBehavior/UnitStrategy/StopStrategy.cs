using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopStrategy : IUnitStrategy
{
    private NavMeshAgent _navMeshAgent;
    private bool _isRunning;

    public StopStrategy(NavMeshAgent navMeshAgent, bool isRunning)
    {
        _navMeshAgent = navMeshAgent;
        _isRunning = isRunning;
    }

    public string GetNameStrategy()
    {
        return "StopStrategy";
    }

    public void Execute()
    {
        _navMeshAgent.isStopped = _isRunning;
    }
}
