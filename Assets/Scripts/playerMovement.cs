using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource footsteps;

    public float moveSpeed = 1.0f;
    public float gravity = -9.81f;

    Vector3 velocity;

    private bool crouched = false;
    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //If player presses the circle button
        if (Input.GetButtonDown("Crouch Controller"))
        {
            Debug.Log("Crouched");

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If player is on ground and not moving, set velocity to -2 (works better)
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal Controller");
        float z = Input.GetAxis("Vertical Controller");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Play footstep sound if player is moving
        if (move.magnitude == 0)
        {
            footsteps.Play();
        }
    }
}
