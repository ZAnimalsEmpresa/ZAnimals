using UnityEngine;

public class BaseStats
{
    public BaseSO baseStats;

    private float _baseHP;
    private BaseType _baseType;

    public BaseStats(BaseSO baseSO)
    {
        baseStats = baseSO;
        _baseHP = baseStats.baseHP;
        _baseType = baseStats.baseType;
    }

    public float BaseHP { get => _baseHP; set => _baseHP = value; }
    public BaseType BaseType { get => _baseType; set => _baseType = value; }
}
