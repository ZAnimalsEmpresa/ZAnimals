using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public UnitSO unitSO;
    //[HideInInspector]
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

    public double currentLife;
    public GameObject targetUnitStats;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = unitSO.life;
        Debug.Log($"life properties {this}: " + unitSO.life);
        Debug.Log($"currentlife this {this}: "+ currentLife);
    }
        
    public void DealDamage(GameObject target)
    {
        targetUnitStats = target;
        if (target != null)
        {
            TakeDamage(target);
        }
    }

    public void TakeDamage(GameObject targetUnit)
    {
        if (currentLife > 0)
        {
            currentLife -= unitSO.attack;
            Debug.Log($"Vida Actual: {unitSO.unitFaction} = {currentLife}");
            if (currentLife <= 0)
            {
                Destroy(targetUnit.transform.parent.gameObject);
            }
        }
        else
        {
            Destroy(targetUnit.transform.parent.gameObject);
        }
    }
}
