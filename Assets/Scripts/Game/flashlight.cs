using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject lightObj;
    public AudioSource onOffClick;

    bool flashlightEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight Controller"))
        {
            flashlightEnabled = !flashlightEnabled;
            onOffClick.Play();
        }

        if (flashlightEnabled)
        {
            lightObj.SetActive(true);
        }
        else
        {
            lightObj.SetActive(false);
        }
    }
}
