using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : MonoBehaviour
{
    public NavMeshAgent navmeshAgent;
    public Transform[] waypoints;
    private Animator animator;
    int index;
    Vector3 targets;
    void Start()
    {
        animator = GetComponent<Animator>();
        navmeshAgent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        animator.SetFloat("Speed", navmeshAgent.speed);
        if (Vector3.Distance(transform.position, targets) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        targets = waypoints[index].position;
        navmeshAgent.SetDestination(targets);
    }

    void IterateWaypointIndex()
    {
        index++;
        if (index == waypoints.Length)
        {
            index = 0;
        }
    }
}
