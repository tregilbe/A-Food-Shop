using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, I_Interactable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening door!");
        return true;
    }
}
