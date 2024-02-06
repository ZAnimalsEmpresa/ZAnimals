using UnityEngine.AI;

public class UnitContext 
{
    private IUnitStrategy _unitStrategy;

    public UnitContext(IUnitStrategy unitStrategy)
    {
        _unitStrategy = unitStrategy;
    }

    public void SetStrategy(IUnitStrategy unitstrategy)
    {
        _unitStrategy = unitstrategy;
    }

    public void ExecuteStrategy()
    {
        _unitStrategy.Execute();
    }
    public void StopCurrentStrategy(NavMeshAgent navMeshAgent, bool isRunning)
    {
        // Crear y ejecutar una estrategia de detención
        var stopStrategy = new StopStrategy(navMeshAgent, isRunning); // Suponiendo que _navMeshAgent está disponible
        stopStrategy.Execute();
    }
}
