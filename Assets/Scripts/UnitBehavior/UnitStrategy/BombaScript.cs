using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaScript : MonoBehaviour
{
    public float boteForce = 10f;
    public double areaDamage = 25.0; 
    public double bounceDamage = 10.0; 

    private bool haColisionado = false;
    private Rigidbody rb;
    private HealthController healthController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //healthController = GetComponent<HealthController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!haColisionado)
        {
            rb.AddForce(Vector3.up * boteForce, ForceMode.Impulse);
            haColisionado = true;

            if (other.gameObject.CompareTag("Enemy"))
            {
                healthController = other.gameObject.GetComponent<UnitScript>().healthController;
                healthController.TakeDamage(bounceDamage);
            }
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 10f); 
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    HealthController enemyHealth = collider.GetComponent<UnitScript>().healthController;
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(areaDamage);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}