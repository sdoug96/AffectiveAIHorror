using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for handling the key logic within the application
//If a player is in range and presses the interact button, they will pick up this key

public class key : MonoBehaviour
{
    //References
    public playerMovement player;

    //Can key be picked up
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //If player is in range of key
        if (Input.GetButtonDown("Interact Controller"))
        {
            PickupKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the object in the trigger is the player
        if (other.tag == "Player")
        {
            //Set active
            active = !active;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Set inactive
        active = !active;
    }

    void PickupKey()
    {
        //If key can be picked up
        if (active)
        {
            //Give player key, play sound and destroy object
            player.hasKey = true;
            player.keySound.Play();
            Destroy(gameObject);
        }
    }
}