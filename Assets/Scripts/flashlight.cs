using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject flashlightObj;
    public GameObject lightObj;

    bool flashlightEnabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            flashlightEnabled = !flashlightEnabled;
        }

        if (flashlightEnabled)
        {
            flashlightObj.SetActive(true);
        }
        else
        {
            flashlightObj.SetActive(false);
        }
    }
}
