using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float sensitivity = 500.0f;

    public Transform player;

    float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("RightJoystickX") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("RightJoystickY") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        player.Rotate(Vector3.up * mouseX);
    }
}
