using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Scriptable Object/Unit")]

public class UnitSO : ScriptableObject
{
    public unitSize unitSize;
    public unitFaction unitFaction;
    public int cost;
    public int reward;
    public int initialLife;
    public int currentLife;
    public int attack;    
    public int rangeAttack;
    public int rateFire;
    public int speedMovement;
    //public enum rangeAttack {short, medium, long}
    //public enum rateFire {slow, medium, fast}
    //public enum speedMovement {slow, medium, fast}
}
public enum unitFaction {ally, enemy}
public enum unitSize {basic, medium, turret}