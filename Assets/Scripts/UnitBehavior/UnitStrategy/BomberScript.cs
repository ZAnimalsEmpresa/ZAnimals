using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : MonoBehaviour
{
    public GameObject bomberSphere; 
    public float shootingCooldown = 5f; 
    public float sphereColliderRadius = 10f; 

    private float lastShotTime = 0f;
    private Transform target; 

    private void Update()
    {
        if (Time.time - lastShotTime >= shootingCooldown)
        {
            FindTarget(); 
            lastShotTime = Time.time;
        }
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereColliderRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                target = collider.transform;
                ShootAtTarget();
                break;
            }
        }
    }

    private void ShootAtTarget()
    {
        if (target != null)
        {
            Vector3 launchDirection = (target.position - transform.position).normalized;
            GameObject newSphere = Instantiate(bomberSphere, transform.position + launchDirection, Quaternion.identity);
            Rigidbody rb = newSphere.GetComponent<Rigidbody>();
            rb.velocity = launchDirection * 10f;
        }
    }
}