using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource footsteps;

    public float speed = 12.0f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded, crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If player presses the circle button
        if (Input.GetKeyDown("joystick button 2"))
        {
            //If player is crouched, stand up
            if (crouched)
            {
                controller.height = 3.8f;
                crouched = false;
            }
            //If player is stood up, crouch
            else
            {
                controller.height = 1.5f;
                crouched = true;
            }
        }

        //If player is on ground and not moving, set velocity to -2 (works better)
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
