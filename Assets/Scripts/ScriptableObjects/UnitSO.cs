using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Scriptable Object/Unit")]

public class UnitSO : ScriptableObject
{
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
    [TextArea(2,2)]
    public string description;
    //public enum rangeAttack {short, medium, long}
    //public enum rateFire {slow, medium, fast}
    //public enum speedMovement {slow, medium, fast}
}

public enum unitFaction {ally, enemy}
public enum unitSize {basic, medium, large, turret}
public enum unitAttackType {melee, ranged}
public enum unitSpecialSkill {None, HiddenAmongUnits, HiddenUnderground, TurretAttack, OnlyBaseAttack}