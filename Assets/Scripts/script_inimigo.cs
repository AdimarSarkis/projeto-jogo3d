using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script_inimigo : MonoBehaviour
{
    NavMeshAgent agente;
    private Rigidbody rbd;
    public GameObject pc;
    public GameObject[] waypoints = new GameObject[12];
    private int index = 0;
    public float maxDist = 4;
    private bool perseguicao = false;
    public float maxDistAlvo = 20;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        rbd = GetComponent<Rigidbody>();
        proximoWaypoint();
    }

    private void proximoWaypoint()
    {
        agente.SetDestination(waypoints[index++].transform.position);
        if (index >= waypoints.Length)
        {
            index = 0;
        }
    }

    private void verificaDistanciaPC()
    {
        if (Vector3.Distance(transform.position, pc.transform.position) > maxDistAlvo && perseguicao == true)
        {
            perseguicao = false;
            proximoWaypoint();
        }
        if (perseguicao || Vector3.Distance(transform.position, pc.transform.position) <= maxDistAlvo)
        {
            perseguicao = true;
            agente.SetDestination(pc.transform.position);
        }
    }

    private void verificaDistanciaWaypoint()
    {
        if (Vector3.Distance(transform.position, agente.destination) < maxDist)
        {
            proximoWaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        verificaDistanciaPC();
        verificaDistanciaWaypoint();
    }
}
