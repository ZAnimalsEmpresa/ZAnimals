using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemyUnitBehavior : MonoBehaviour
{
    public UnitSO basicUnitEnemy;

    UnitBehaviour UnitBH;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        print("Entra oncollisionEnemy");

        if (other.gameObject.CompareTag("Ally"))
        {
            print("Entra if");
            //Esta siempre atacando, no cada 1 seg como deberia
            //InvokeRepeating(nameof(UnitBH.DealDamage(other), 0, 1f * Time.deltaTime);
            UnitBH.DealDamage(other.GetComponent<TestAllyUnitBehavior>().gameObject);
        }
    }
}
