using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{

    [SerializeField] GameObject customers;
    [SerializeField] float spawningInterval = 3.5f;
    [SerializeField] Transform location;
    Button shopDoor;
    public GameObject door;

    public int spawnCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        shopDoor = door.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (shopDoor.doorOpen == true)
        {
            if (spawnCount < 3)
            {
                StartCoroutine(spawnCustomer(spawningInterval, customers));
                spawnCount++;
            }
        }
        
    }

    private IEnumerator spawnCustomer(float timer, GameObject customersSpawning)
    {

        yield return new WaitForSeconds(timer);
        GameObject newCustomer = Instantiate(customersSpawning, location);

        
    }
}
