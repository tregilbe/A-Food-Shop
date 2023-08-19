using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public float timer;



    IEnumerator ToggleDoor()
    {
        yield return new WaitForSeconds(timer);
        doorOpen = false;
        gameObject.transform.Rotate(0, -90, 0);
        Debug.Log("Door closed");
    }


}
