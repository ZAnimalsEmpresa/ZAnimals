using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField]
    private UnitSO _unitSO;
    public HealthController healthController;

    private unitSize _unitSize;
    public unitFaction unitFaction;
    private unitSpecialSkill _unitSpecialSkill;
    private unitAttackType _unitAttackType;
    private int _cost;
    private int _reward;
    private double _life;
    public double attackValue;
    public float rangeAttack;
    private float _rateFire;
    private float _speedMovement;

    public double currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = _unitSO.life;
        healthController.maxHealth = currentLife;
        _unitSize = _unitSO.unitSize;
        unitFaction = _unitSO.unitFaction;
        _unitSpecialSkill = _unitSO.unitSpecialSkill;
        _unitAttackType = _unitSO.unitAttackType;
        _cost = _unitSO.cost;
        _reward = _unitSO.reward;
        attackValue = _unitSO.attack;
        rangeAttack = _unitSO.rangeAttack;
        _rateFire = _unitSO.rateFire;
        _speedMovement = _unitSO.speedMovement;
    }
}
