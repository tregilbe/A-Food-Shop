using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBottle : MonoBehaviour
{
    public Color potionColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjectGrabbable>() != null)
        {
            collision.gameObject.GetComponent<ObjectGrabbable>().PoisonObject(potionColor);
        }
    }
}
