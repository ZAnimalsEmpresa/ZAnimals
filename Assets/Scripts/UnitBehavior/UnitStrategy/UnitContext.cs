using UnityEngine;
using UnityEngine.AI;

public class UnitContext 
{
    private IUnitStrategy _unitStrategy;

    private UnitAnimations _unitAnimations;

    public UnitContext(IUnitStrategy unitStrategy, UnitAnimations animator)
    {
        _unitStrategy = unitStrategy;
        _unitAnimations = animator;
    }

    public void SetStrategy(IUnitStrategy unitstrategy)
    {
        _unitStrategy = unitstrategy;
    }

    public string GetNameStrategy()
    {
        return _unitStrategy.GetNameStrategy();
    }

    public void ExecuteStrategy()
    {
        _unitStrategy.Execute();
        _unitAnimations.PlayAnimation(GetNameStrategy());
    }

    public void StopCurrentStrategy(NavMeshAgent navMeshAgent, bool isRunning)
    {
        // Crear y ejecutar una estrategia de detención
        var stopStrategy = new StopStrategy(navMeshAgent, isRunning); // Suponiendo que _navMeshAgent está disponible
        stopStrategy.Execute();
    }
}
