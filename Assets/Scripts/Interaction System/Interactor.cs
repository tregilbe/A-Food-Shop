using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // interaction variables
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactibleMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private I_Interactable _interactable;
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
            _interactibleMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<I_Interactable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E)) _interactable.Interact(this);
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
