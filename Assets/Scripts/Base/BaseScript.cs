using UnityEngine;
using UnityEngine.Events;

public class BaseScript : MonoBehaviour
{
    [SerializeField]
    private BaseSO _baseSO;
    public BaseStats baseStats;
    public BaseHPController baseHPController;
    public UnityEvent OnDeadBase;

    private void Awake()
    {
        baseStats = new BaseStats(_baseSO);
        baseHPController = new BaseHPController(this, OnDeadBase);
        baseHPController.OnBaseDestroy += HandleDestroyStateChanged;
    }

    public void HandleDestroyStateChanged()
    {
        // Lógica para manejar el cambio al estado de muerte
        baseHPController.OnBaseDestroy -= HandleDestroyStateChanged;
    }
}
