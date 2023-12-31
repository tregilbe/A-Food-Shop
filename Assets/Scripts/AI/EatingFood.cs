using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EatingFood : MonoBehaviour
{
    [SerializeField] AINavigation ai;
    SpawningSystem spawnsystem;
    public GameObject points;
    public GameObject miniMe;
    public Transform spawner;
    public GameObject poisonFood;

    public AudioSource audioSource;
    public AudioClip audioClip;
    
    
    private ObjectGrabbable poison;
    private void Awake()
    {
        poison = FindObjectOfType<ObjectGrabbable>();
        spawnsystem = FindObjectOfType<SpawningSystem>();
        Assert.IsNotNull(poison);
    }

    private void Start()
    {
        //poison = poisonFood.GetComponent<ObjectGrabbable>();
        //spawnsystem = points.GetComponent<SpawningSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poison")
        {
            audioSource.PlayOneShot(audioClip);
            //print("Dead!!!!");
            Destroy(other.gameObject);
            spawnsystem.spawnCount--;
            Instantiate(miniMe, spawner.position, spawner.rotation);
            ai.EnableRagDoll();
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject, 2);
            }
            Destroy(this.gameObject, 1);
        }
        else if(other.gameObject.tag == "Food")
        {
            //print("Yummy");
            Destroy(other.gameObject);
            audioSource.PlayOneShot(audioClip);
            spawnsystem.spawnCount--;
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject,2);
            }
            Destroy(this.gameObject,1);

        }
    }
}
