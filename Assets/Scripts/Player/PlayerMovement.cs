using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to player controller
    public CharacterController controller;
  
    // allows for control of player speed
    public float speed = 12f;

    // Variables for gravity control
    public float gravity = -9.81f;
    Vector3 velocity;

    // Jump variables
    public float jumpHeight = 3f;

    // Ground check 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Crouch variables
    public float normalHeight, crouchHeight;

    // Update is called once per frame
    void Update()
    {
        // Use Unity physics to check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If they are, set velocity to small negative number/reset velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Use Unitys built in movement system - compatible with keyboard and controller
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Set it to move locally instead of world
        Vector3 move = transform.right * x + transform.forward * z;

        // uses player controller and the new vector to move, using time.deltatime to avoid framerate
        controller.Move(move * speed * Time.deltaTime);

        // OPTIONAL Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Crouch mechanic
        if (Input.GetKeyDown(KeyCode.C))
        {
            controller.height = crouchHeight;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            controller.height = normalHeight;
        }

        // Apply gravity over time
        velocity.y += gravity * Time.deltaTime;

        // Physics of free fall
        controller.Move(velocity * Time.deltaTime);
    }
}
