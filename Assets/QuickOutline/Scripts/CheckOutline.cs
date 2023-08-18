using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }
}
