using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public Transform target;
    private Color originalColor; 

    void Start()
    {
        target = Camera.main.GetComponent<Transform>();
        originalColor = GetComponent<Renderer>().material.color; 
    }
    
    void Update()
    {
        transform.LookAt(target);
    }
    public void IsPoisoned()
    {
        GetComponent<Renderer>().material.color = Color.magenta;
    }

    // Función para restablecer el color original
    public void ResetColorBar()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
}

