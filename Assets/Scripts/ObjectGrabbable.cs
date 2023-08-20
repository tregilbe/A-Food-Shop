using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    // Get object rigid body, and the players grab point
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    // boolean to keep track what is poisoned
    public bool isPoisoned = false;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        // Set transform of object to grab point
        this.objectGrabPointTransform = objectGrabPointTransform;

        // Disable objects gravity so it does not jitter
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            // make a new vector, and use lerp to smooth movement from current place to target grab point over time
            float lerpSpeed = 10f;
            Vector3 newPosisiton =  Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosisiton);
        }
    }

    public void PoisonObject(Color newColor)
    {
        // set bool to true
        isPoisoned = true;
        // set the tag to Poison
        gameObject.tag = "Poison";
        // activate the particle system for poison effect

        // Give item slightly green tone?
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrashCan")
        {
            Destroy(gameObject);
        }
    }
}
