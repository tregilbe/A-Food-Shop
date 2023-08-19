using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    [SerializeField] Transform ChairPosition;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }


    private void Update()
    {
        agent.destination = ChairPosition.position;
    }

}
