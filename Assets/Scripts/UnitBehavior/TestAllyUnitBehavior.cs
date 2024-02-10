using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestAllyUnitBehavior : MonoBehaviour
{
    public UnitSO basicUnitAlly;

    //UnitBehaviour UnitBH;

    // Update is called once per frame
    void Update()
    {
        //Movimiento del aliado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();
        transform.position = transform.position + movementDirection * basicUnitAlly.speedMovement * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        print("Entra oncollisionAlly");

        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Entra if");
            //Esta siempre atacando, no cada 1 seg como deberia
            //InvokeRepeating(nameof(UnitBH.DealDamage), 0, 1f * Time.deltaTime);
            //UnitBH.DealDamage(other.GetComponent<TestEnemyUnitBehavior>().gameObject);
        }
    }
}
