using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    [SerializeField] float range;
    private NavMeshAgent agent;
    SeatingManagement sm;
    public GameObject chairs;
    int i = 0;
    private bool hitOnce = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sm = chairs.GetComponent<SeatingManagement>();
        agent.destination = sm.Chairs[i].transform.position;
    }

    private void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray raycast = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range), Color.red);


        agent.destination = sm.Chairs[i].transform.position;

        if (Physics.Raycast(raycast, out RaycastHit hit, range))//check if it empty
        {
            if (hit.collider.tag == "Customer" && !hitOnce)
            {
                hitOnce = true;
                //print("Occpied");

                if (i == 0)
                {
                    i = 1;
                }
                else if (i == 1)
                {
                    i = 2;
                }
                else if (i == 2)
                {
                    i = 0;
                }

            }
            else if (hitOnce)
            {
                hitOnce = false;
            }
        }
    }
}


