using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAllyUnitBehavior : MonoBehaviour
{
    public UnitSO basicUnitAlly;
    public UnitSO basicUnitEnemy;
    public GameObject enemigo;
    float speedAlly;
    float rotationSpeed = 5f;
    int currentEnemyLife;

    void Start()
    {
        currentEnemyLife = basicUnitEnemy.currentLife;
        print("Enemigo vida Inicial: " + currentEnemyLife);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del aliado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput,0,verticalInput);
        movementDirection.Normalize();
        speedAlly = basicUnitAlly.speedMovement;
        transform.position = transform.position + movementDirection * speedAlly * Time.deltaTime;

        //Para que rote con la camara
        //if (movementDirection != Vector3.zero)
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        print("Entra oncollision");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Entra if");
            //Esta siempre atacando, no cada 1 seg como deberia
            InvokeRepeating(nameof(attack), 0, 1f * Time.deltaTime);   
        }
    }

    public void attack()
    {
        if (currentEnemyLife>0)
        {
            currentEnemyLife -= basicUnitAlly.attack;
            print("Enemigo Vida Actual: " + currentEnemyLife);
        }
    }
}
