using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, I_Interactable
{
    [SerializeField] private string prompt;
    private AudioSource audioSource;

    public float manaGoal = 100;
    public float currentMana = 0;

    public string InteractionPrompt => prompt;

    [SerializeField] private GameObject player;

    private void Start()
    {
        currentMana = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool Interact(Interactor interactor)
    {
        if (currentMana >= manaGoal)
        {
            // if player has enough mana, they win
            Debug.Log("You Win!");
            player.GetComponent<PlayerMenuManager>().activateWinMenu();
        }
        else
        {
            Debug.Log("Crystal requires more mana");
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        prompt = currentMana + "/" + manaGoal + " Mana";
    }
}