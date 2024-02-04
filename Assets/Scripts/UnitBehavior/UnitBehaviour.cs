using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    public TestAllyUnitBehavior basicUnitAlly;
    public TestEnemyUnitBehavior basicUnitEnemy;

    public void DealDamage(GameObject target)
    {
        /* if (currentEnemyLife > 0)
         {
             currentEnemyLife -= basicUnitAlly.attack;
             print("Enemigo Vida Actual: " + currentEnemyLife);
         }*/
        print("Entra dealdamage");
        var unit = target.GetComponent<UnitSO>();
        if(unit != null)
        {
            print("Entra if dealdamage");
            TakeDamage(unit.attack, unit);
        }
         
    }

    public void TakeDamage(int amount, UnitSO unit)
    {
        print("Entra takedamage");
        unit.currentLife -= amount;
        print($"Vida Actual: {unit.unitFaction} = {unit.currentLife}");
    }

}
