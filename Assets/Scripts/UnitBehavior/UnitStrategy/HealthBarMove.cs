using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMove : MonoBehaviour
{
    public Transform target; // El objeto al que queremos mirar

    void Update()
    {
        // Rotamos la cámara cada cuadro para que siga mirando al objetivo
        transform.LookAt(target);
    }
}

