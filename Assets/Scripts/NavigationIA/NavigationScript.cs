using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agent;
    public float rangoDeAlerta;
    public LayerMask capaDelEnemigo;
    bool estarAlerta;
    public Transform tropaEnemiga;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelEnemigo);

        if (estarAlerta == true)
        {
            transform.LookAt(tropaEnemiga);
            agent.destination = tropaEnemiga.position;
        }
        else
        {
            agent.destination = objetivo.position;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta); // Add the missing semicolon here
    }
}