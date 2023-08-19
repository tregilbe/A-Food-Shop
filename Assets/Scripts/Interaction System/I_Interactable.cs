using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Interactable
{
    // Base variables for all interactable
    public string InteractionPrompt { get; }
    public bool Interact(Interactor iteractor);

}
