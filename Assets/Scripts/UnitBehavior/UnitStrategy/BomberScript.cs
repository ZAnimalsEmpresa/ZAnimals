using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : MonoBehaviour
{
public GameObject bomberSphere; // Assign the prefab for the sphere

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            LaunchSphere();
        }
    }

    private void LaunchSphere()
    {
        Vector3 launchDirection = transform.forward;
        GameObject newSphere = Instantiate(bomberSphere, transform.position + launchDirection, Quaternion.identity);
        Rigidbody rb = newSphere.GetComponent<Rigidbody>();
        rb.velocity = launchDirection * 10f; // Set constant forward velocity
    }
}