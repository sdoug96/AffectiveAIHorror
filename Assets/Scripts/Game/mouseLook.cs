using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    //References
    public heartRateMonitor HRM;
    public playerEmotions emotions;
    public Transform player;

    //Look sensitivity
    public float sensitivity = 200.0f;

    //X rotation of camera
    float xRotation = 0.0f;

    //Can look around
    public bool canLook = true;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //If no heartrate or face is detected
        if (HRM.BPM == 0 || !emotions.faceInView)
        {
            //Disable input
            canLook = false;
        }
        //If heartrate and face are detected
        else
        {
            //Enable input
            canLook = true;
        }

        if (canLook)
        {
            //Camera rotation values based on controller right joystick input
            float lookX = Input.GetAxis("RightJoystickX") * sensitivity * Time.deltaTime;
            float lookY = Input.GetAxis("RightJoystickY") * sensitivity * Time.deltaTime;

            //Rotate camera based on camera rotation values
            xRotation -= lookY;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

            player.Rotate(Vector3.up * lookX);
        }
    }
}