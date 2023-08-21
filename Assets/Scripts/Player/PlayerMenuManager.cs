using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;

    public GameObject mainCamera;

    private CharacterController characterController;
    private PlayerMovement playermovement;
    private MouseLook mouseLook;

    // [SerializeField] private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set all menus to inactive at start, just in case
        PauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);

        characterController = gameObject.GetComponent<CharacterController>();
        playermovement = gameObject.GetComponent<PlayerMovement>();
        mouseLook = mainCamera.GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
    }

    // Create public voids to active the menus, letting them be accessed from other scripts if need be
    public void activatePauseMenu()
    {
        PauseMenu.SetActive(true);
        playermovement.enabled = false;
        characterController.enabled = false;
        //isPaused = true;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera.transform.LookAt(PauseMenu.transform.position);
    }

    public void activateWinMenu()
    {
        WinMenu.SetActive(true);
        playermovement.enabled = false;
        characterController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera.transform.LookAt(WinMenu.transform.position);
    }

    public void activateLoseMenu()
    {
        LoseMenu.SetActive(true);
        playermovement.enabled = false;
        characterController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera.transform.LookAt(LoseMenu.transform.position);
    }
}