using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyUnitBehavior : MonoBehaviour
{
    public UnitSO basicUnitEnemy;
    float speedEnemy;
    int currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = basicUnitEnemy.currentLife;
        print("Enemigo Vida Inicial: " +currentLife);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();
        speedEnemy = basicUnitEnemy.speedMovement;
        transform.position = transform.position + movementDirection * speedEnemy * Time.deltaTime;
        */
    }

    /*public void AttackMe (int attack)
    {
        currentLife -= attack;
        print("Aliado Ataque: " + attack);
        print("Enemigo Vida Actual: " + currentLife);
    }*/
}
