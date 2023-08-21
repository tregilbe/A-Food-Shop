using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip burnTrash;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = burnTrash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(burnTrash);
        }
    }
}
