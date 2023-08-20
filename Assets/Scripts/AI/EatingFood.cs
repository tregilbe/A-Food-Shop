using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EatingFood : MonoBehaviour
{
    [SerializeField] AINavigation ai;
    

    public GameObject poisonFood;
    private ObjectGrabbable poison;
    private void Awake()
    {
        poison = FindObjectOfType<ObjectGrabbable>();
        Assert.IsNotNull(poison);
    }

    private void Start()
    {
        poison = poisonFood.GetComponent<ObjectGrabbable>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poison")
        {
            print("Dead!!!!");
            ai.EnableRagDoll();
            Destroy(GameObject.FindWithTag("Poison"));
        }
    }
}
