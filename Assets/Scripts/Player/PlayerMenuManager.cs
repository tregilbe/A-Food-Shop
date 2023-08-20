using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;

    public CharacterController characterController;

    [SerializeField] private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set all menus to inactive at start, just in case
        PauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);

        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            activatePauseMenu();
        }
        else
        {
            PauseMenu.SetActive(false);
            //characterController.enabled = true;
            isPaused = false;
        }
    }

    // Create public voids to active the menus, letting them be accessed from other scripts if need be
    public void activatePauseMenu()
    {
        PauseMenu.SetActive(true);
        //characterController.enabled = false;
        isPaused = true;
    }

    public void activateWinMenu()
    {
        WinMenu.SetActive(true);
    }

    public void activateLoseMenu()
    {
        LoseMenu.SetActive(true);
    }
}
