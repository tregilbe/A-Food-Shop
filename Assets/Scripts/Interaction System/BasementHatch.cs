using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementHatch : MonoBehaviour, I_Interactable
{

    [SerializeField] private string prompt;

    [SerializeField] private Transform TargetEntryPoint;
    [SerializeField] private Transform ItemTargetPoint;

    //public GameObject player;

    private void Start()
    {
        
    }

    public string InteractionPrompt => prompt;
    public bool Interact(Interactor interactor)
    {
        // make a vector 3 out of target transform
        Vector3 target = new Vector3 (TargetEntryPoint.position.x, TargetEntryPoint.position.y, TargetEntryPoint.position.z);

        // disable player controller to teleport
        //player.GetComponent<CharacterController>().enabled = false;

        // teleport player to the area
        //player.GetComponent<Transform>().position = target;

        // re enable the character controller
        //player.GetComponent<CharacterController>().enabled = true;

        Debug.Log("Tried to move player to basement");
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            other.transform.position = ItemTargetPoint.position;
        }
    }
}
