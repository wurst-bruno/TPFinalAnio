using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public Transform destinationTransform;
    public NavMeshAgent agent;
    public static bool seguirplayer;
    GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destinationTransform.position;
    }
}