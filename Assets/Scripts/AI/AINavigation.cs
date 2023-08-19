using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AINavigation : MonoBehaviour
{
    [SerializeField] float range;
    private NavMeshAgent agent;
    SeatingManagement sm;
    public GameObject chairs;
    private bool hitOnce = false;
    //public Transform plate;
    int i;
    private float fixedRotation = 5;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sm = chairs.GetComponent<SeatingManagement>();
        i = Random.Range(0, sm.Chairs.Length);
        agent.destination = sm.Chairs[i].transform.position;
    }

    private void Update()
    {
        float dist = agent.remainingDistance;

        GettingToChair();
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            transform.eulerAngles = new Vector3(eulerAngles.x, fixedRotation, eulerAngles.z);
        }
    }

    public void GettingToChair()
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


