using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for controlling the player character and whether they have a key or not
//It also holds the audio for the player's footsteps and picking up a key

public class playerMovement : MonoBehaviour
{
    public heartRateMonitor HRM;
    public playerEmotions emotions;

    public CharacterController controller;
    public AudioSource footsteps;
    public AudioSource keySound;

    public float moveSpeed = 1.0f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public bool canMove = true;

    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //If no heartrate or face is detected
        if (HRM.BPM == 0 || !emotions.faceInView)
        {
            //Disable input
            canMove = false;
        }
        //If heartrate and face are detected
        else
        {
            //Enable input
            canMove = true;
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

        if (canMove)
        {
            //Movement values based on controller left joystick input
            float x = Input.GetAxis("Horizontal Controller");
            float z = Input.GetAxis("Vertical Controller");

            //Move the player based on movement values
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
        else
        {
            footsteps.Stop();
        }
    }
}