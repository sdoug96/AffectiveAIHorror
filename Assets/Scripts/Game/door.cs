using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is responsible for handling the doors within the application
//Values will determine whether the door is locked or not, which way it is facing and whether it is already open
//Query door function will determine what happens when the player interacts with a door

public class door : MonoBehaviour
{
    private Animator animator;
    public AudioSource openSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;
    public playerMovement player;
    public puzzleTimesAndAttention timesAndAttention;

    public int puzzleID = 0;

    private bool isOpen = false, active = false;
    public bool isLocked = false, left = false, right = false, back = false, end = false;

    // Start is called before the first frame update
    void Start()
    {
        //Find animator and audio components
        animator = GetComponent<Animator>();

        //Set direction of animation
        if (left)
        {
            animator.SetBool("left", true);
        }
        else if (right)
        {
            animator.SetBool("right", true);
        }
        else if (back)
        {
            animator.SetBool("back", true);
        }
    }

    //Player enters door trigger
    private void OnTriggerEnter(Collider other)
    {
        //If door is not already open
        if (!isOpen)
        {
            //If the object in the trigger is the player
            if (other.tag == "Player")
            {
                //Set active
                active = !active;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Set door inactive if player leaves and doesn't open the door
        active = !active;
    }

    // Update is called once per frame
    void Update()
    {
        //If player is in range of door
        if (Input.GetButtonDown("Interact Controller"))
        {
            QueryDoor();
        }
    }

    void QueryDoor()
    {
        //If the door is unlocked
        if (!isOpen)
        {
            if (active)
            {
                //Door is unlocked
                if (!isLocked)
                {
                    //Open door
                    OpenDoor();
                }
                //Door is locked
                else
                {
                    if (player.hasKey)
                    {
                        //Play unlocked audio
                        unlockedSound.Play();

                        //Open door when unlocked audio is finished
                        Invoke("OpenDoor", 0.5f);

                        //take key from player
                        player.hasKey = false;

                        //If the first puzzle is completed
                        if (puzzleID == 1)
                        {
                            //Set puzzle 1 time and reset timer
                            timesAndAttention.puzzle1Time = timesAndAttention.timer;
                            timesAndAttention.timer = 0.0f;
                        }

                        //If the second puzzle is completed
                        if (puzzleID == 2)
                        {
                            //Set puzzle 2 time
                            timesAndAttention.puzzle2Time = timesAndAttention.timer;
                            timesAndAttention.timer = 0.0f;
                        }

                        //If this is the last door
                        if (end)
                        {
                            //Set puzzle 3 time
                            timesAndAttention.puzzle3Time = timesAndAttention.timer;
                            //End application
                            Invoke("QuitApplication", 0.5f);
                        }
                    }
                    else
                    {
                        //Play audio
                        lockedSound.Play();
                    }
                }
            }
        }
    }

    void OpenDoor()
    {
        //Set is open, play animation, play audio
        isOpen = !isOpen;
        animator.SetBool("open", true);
        openSound.Play();
    }

    void QuitApplication()
    {
        //Exit editor play mode
        UnityEditor.EditorApplication.isPlaying = false;
    }
}