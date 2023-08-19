using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    private Button button;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                // Not carrying an object, try to grab
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log("I tried to pick up " + objectGrabbable);
                    }
                }
            } 
            else if (button != null)
            {
                // Not carrying an object, try to interact
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out button))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log("I tried to pick up " + objectGrabbable);
                    }
                }
            }
            else
            {
                // Currently carrying something, drop
                Debug.Log("I tried to drop the item");
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
