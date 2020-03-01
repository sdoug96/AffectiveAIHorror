using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    private Animator animator;
    public AudioSource openSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;
    public GameObject openText = null;
    public GameObject lockedText = null;
    public playerMovement player;

    private bool isOpen = false, active = false;
    public bool isLocked = false, left = false;

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
                //Show open prompt and set in range
                openText.SetActive(true);
                active = !active;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Kill open prompt if player leaves and doesn't open the door
        openText.SetActive(false);
        lockedText.SetActive(false);
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
            //kill open prompt
            openText.SetActive(false);

            if (active)
            {
                //Door is unlocked
                if (!isLocked)
                {
                    //Set is open, play animation, play audio
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
                    }
                    else
                    {
                        //Show locked prompt, play audio
                        lockedText.SetActive(true);
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
}
