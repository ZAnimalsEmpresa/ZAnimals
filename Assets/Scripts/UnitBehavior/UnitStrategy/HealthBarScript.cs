using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = Camera.main.GetComponent<Transform>();
    }
    
    void Update()
    {
        transform.LookAt(target);
    }
}

