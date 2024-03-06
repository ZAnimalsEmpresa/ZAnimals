using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Scriptable Object/Unit")]

public class UnitSO : ScriptableObject
{
    public UnitSize unitSize;
    public UnitFaction unitFaction;
    public UnitSpecialSkill unitSpecialSkill;
    public UnitAttackType unitAttackType;
    public int cost;
    public int reward;
    public double health;
    public double attack;
    public double poisonDamage;
    public float rangeAttack;
    public float rateFire;
    public float speedMovement;
    [TextArea(2,2)]
    public string description;
    //public enum rangeAttack {short, medium, long}
    //public enum rateFire {slow, medium, fast}
    //public enum speedMovement {slow, medium, fast}
}

public enum UnitFaction {Ally, Enemy}
public enum UnitSize {basic, medium, large, turret}
public enum UnitAttackType {melee, ranged}
public enum UnitSpecialSkill {None, HiddenAmongUnits, HiddenUnderground, TurretAttack, OnlyBaseAttack, PoisonAttack}