using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool doorOpen = false;

    public ShopDoor shopDoor;

    public GameObject openDoor;
    public GameObject closedDoor;

    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyUp(KeyCode.E) && doorOpen == false)
        {
            OpenDoor();
        }
        else if (triggerActive && Input.GetKeyUp(KeyCode.E) && doorOpen == true)
        {
            CloseDoor();
        }
        else
        {
            Debug.Log("Trigger inactive, no input");
        }
    }

    public void OpenDoor()
    {
        doorOpen = true;

        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

    public void CloseDoor()
    {
        doorOpen = false;

        openDoor.SetActive(false);
        closedDoor.SetActive(true);
    }
}
