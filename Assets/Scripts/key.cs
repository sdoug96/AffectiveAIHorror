﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public playerMovement player;

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
            Debug.Log("Key Found");
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
        if (active)
        {
            //Give player key, play sound and destroy object
            player.hasKey = true;
            player.keySound.Play();
            Destroy(gameObject);
        }
    }
}
