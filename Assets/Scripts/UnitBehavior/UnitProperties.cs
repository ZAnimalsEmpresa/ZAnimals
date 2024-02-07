using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProperties : MonoBehaviour
{
    [SerializeField]
    private UnitSO unitSO;

    public unitSize unitSize;
    public unitFaction unitFaction;
    public unitSpecialSkill unitSpecialSkill;
    public unitAttackType unitAttackType;
    public int cost;
    public int reward;
    public double life;
    public double attack;
    public float rangeAttack;
    public float rateFire;
    public float speedMovement;
    public string description;

    // Start is called before the first frame update
    private void Start()
    {
        unitSize = unitSO.unitSize;
        unitFaction = unitSO.unitFaction;
        unitSpecialSkill = unitSO.unitSpecialSkill;
        unitAttackType = unitSO.unitAttackType;
        cost = unitSO.cost;
        reward = unitSO.reward;
        life = unitSO.life;
        attack = unitSO.attack;
        rangeAttack = unitSO.rangeAttack;
        rateFire = unitSO.rateFire;
        speedMovement = unitSO.speedMovement;
        description = unitSO.description;
    }
}
