using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private GameObject currentItem;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first item when game starts, set reference as well
        currentItem = Instantiate(prefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is an item
        if (currentItem != null)
        {
            // If there is, do nothing
        }
        else
        {
            // If there is no current item, make a new one
            currentItem = Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
