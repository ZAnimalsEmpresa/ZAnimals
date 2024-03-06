using UnityEngine;

[System.Serializable]
public class UnitStats
{
    // Private Serialize
    [SerializeField]
    private bool isBomber;
    // Private
    private UnitSO _unitSO;
    private double _health;
    private float _speedMovement;
    private double _attackValue;
    private double _poisonDamage;
    private float _rangeAttack;
    private float _rateFire;
    private UnitFaction unitFaction;
    private int _cost;
    private int _reward;
    
    public UnitStats(UnitSO unitSO,bool IsBomber)
    {
        isBomber = IsBomber;
        _unitSO = unitSO;
        _health = _unitSO.health;
        unitFaction = _unitSO.unitFaction;
        _cost = _unitSO.cost;
        _reward = _unitSO.reward;
        _attackValue = _unitSO.attack;
        _poisonDamage = _unitSO.poisonDamage;
        _rangeAttack = _unitSO.rangeAttack;
        _rateFire = _unitSO.rateFire;
        _speedMovement = _unitSO.speedMovement;
    }

    public double Health { get => _health; set => _health = value; }
    public float SpeedMovement { get => _speedMovement; set => _speedMovement = value; }
    public double AttackValue { get => _attackValue; set => _attackValue = value; }
    public double PoisonDamage { get => _poisonDamage; set => _poisonDamage = value; }
    public float RangeAttack { get => _rangeAttack; set => _rangeAttack = value; }
    public float RateFire { get => _rateFire; set => _rateFire = value; }
    public UnitFaction UnitFaction { get => unitFaction; set => unitFaction = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public int Reward { get => _reward; set => _reward = value; }
    public bool IsBomber { get => isBomber; set => isBomber = value; }
}
