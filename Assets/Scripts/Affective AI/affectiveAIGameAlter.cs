using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for holding all of the logic for the various different jumpscares contained within the application
//The play jumpscare script will call the relevant jumpscare from here using an ID

public class affectiveAIGameAlter : MonoBehaviour
{
    //Flashlight flicker variables
    public GameObject flashlight;
    public Animator flashlightAnim;
    AudioSource flashlightFlicker;

    //Lights jumpscare variables
    public GameObject[] lights;
    public AudioSource lightsSound;
   
    //Spotlight jumpscare variables
    public GameObject spotLight;
    AudioSource spotlightSound;

    //Trolley jumpscare variables
    public Rigidbody trolleyRB;

    //Trolley jumpscare variables
    public Rigidbody chairRB;

    //Trolley jumpscare variables
    public Rigidbody doorRB;

    public AudioSource launchSound;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise flashlight animator controller and audio source
        flashlightAnim = flashlight.GetComponent<Animator>();
        flashlightFlicker = flashlight.GetComponent<AudioSource>();

        //Initialise spotlight audio source
        spotlightSound = spotLight.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FlashlightFlicker()
    {
        //Play flashlight flicker and audio
        flashlightFlicker.Play();
        flashlightAnim.Play("Flicker");
    }

    public void LightsJumpscare()
    {
        //Turn off lights, temp turn off flashlight and play audio
        flashlightAnim.Play("Off");
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        lightsSound.Play();
    }

    public void SpotlightJumpscare()
    {
        //Turn on spotlight and play audio
        spotLight.SetActive(true);
        spotlightSound.Play();
    }

    public void LaunchTrolleyJumpscare()
    {
        //Launch bed towards player and play audio
        trolleyRB.AddForce(7.0f, 20.0f, 7.0f, ForceMode.Impulse);
        launchSound.Play();
    }

    public void LaunchChairJumpscare()
    {
        //Launch chair and play audio
        chairRB.AddForce(-25.0f, 0.0f, 0.0f, ForceMode.Impulse);
        launchSound.Play();
    }

    public void LaunchDoorJumpscare()
    {
        //Launch door and play audio
        doorRB.AddForce(10.0f, 0.0f, 0.0f, ForceMode.Impulse);
        launchSound.Play();
    }
}