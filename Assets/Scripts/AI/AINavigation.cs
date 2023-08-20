using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using static UnityEngine.GraphicsBuffer;

public class AINavigation : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Transform location;
    private Rigidbody[] ragDoll;

    public NavMeshAgent agent;
    SeatingManagement sm;
    public GameObject chairs;

    private Animator animator;
    private bool hitOnce = false;
    //public Transform plate;
    int i;
    private float fixedRotation = 180;

    private void Awake()
    {

        sm = FindObjectOfType<SeatingManagement>();
        Assert.IsNotNull(sm);

        ragDoll = GetComponentsInChildren<Rigidbody>();

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        sm = chairs.GetComponent<SeatingManagement>();
        i = Random.Range(0, sm.Chairs.Length);
        agent.destination = sm.Chairs[i].transform.position;
        DisableRagDoll();
    }

    private void Update()
    {
        if (agent.enabled == true)
        {
            animator.SetFloat("Speed", agent.speed);

            GettingToChair();
            float dist = agent.remainingDistance;
            if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            {
                Vector3 eulerAngles = transform.eulerAngles;
                transform.eulerAngles = new Vector3(eulerAngles.x, fixedRotation, eulerAngles.z);
            }
        }
    }

    public void GettingToChair()
    {

        if (agent.enabled == true)
        {

            Vector3 direction = Vector3.forward;
            Ray raycast = new Ray(location.position, transform.TransformDirection(direction * range));
            Debug.DrawRay(transform.position, transform.TransformDirection(direction * range), Color.red);


            agent.destination = sm.Chairs[i].transform.position;

            if (Physics.Raycast(raycast, out RaycastHit hit, range))//check if it empty
            {
                if (hit.collider.tag == "Customer" && !hitOnce)
                {
                    hitOnce = true;
                    print("Occpied");

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

    private void DisableRagDoll()
    {
        foreach (Rigidbody rigidbody in ragDoll)
        {
            rigidbody.isKinematic = true;
        }
        agent.enabled = true;
        animator.enabled = true;
    }

    public void EnableRagDoll()
    {
        foreach (Rigidbody rigidbody in ragDoll)
        {
            rigidbody.isKinematic = false;
        }
        agent.enabled = false;
        animator.enabled = false;

    }


}


