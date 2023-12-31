using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : Perception
{
    [SerializeField] Transform raycastTransform;

    [SerializeField][Range(2, 50)] public int numRaycast = 2;

    [SerializeField] float detectionPoint = 0;
    private PlayerMenuManager manager;
    public GameObject managerPlayer;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        manager = managerPlayer.GetComponent<PlayerMenuManager>();
    }

    public void Update()
    {
        GetGameObjects();
    }

    public override GameObject[] GetGameObjects()
    {
        List<GameObject> result = new List<GameObject>();

        float angleOffset = (angle * 2) / (numRaycast - 1);
        for (int i = 0; i < numRaycast; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(-angle + (angleOffset * i), Vector3.up);
            Vector3 direction = rotation * raycastTransform.forward;
            Ray ray = new Ray(raycastTransform.position, direction);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, distance))
            {
                if (tagName == "" || raycastHit.collider.CompareTag(tagName))
                {
                    Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.red);
                    result.Add(raycastHit.collider.gameObject);

                    audioSource.PlayOneShot(audioClip);

                    detectionPoint += 1;
                    if (detectionPoint == 100)
                    {
                        manager.activateLoseMenu();
                    }
                }
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
            }
        }
        return result.ToArray();
    }
}
