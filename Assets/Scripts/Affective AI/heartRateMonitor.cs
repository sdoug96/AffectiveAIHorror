using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine;

//This script is responsible for reading in the player's heartrate data from the Arduino script using a serial port

public class heartRateMonitor : MonoBehaviour
{
    //Serial port to communicate with Arduino
    SerialPort arduinoHeartrateMonitor;

    //Bool to turn the heartrate monitor on or off
    public bool active = true;

    //Beats per minute variable
    public int BPM = 60;

    //Warning to show player if no heartrate is detected
    public Text noBPMText;

    //Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            //Intialise heart rate monitor from Arduino IDE
            arduinoHeartrateMonitor = new SerialPort("COM6", 115200);

            arduinoHeartrateMonitor.Open();
            arduinoHeartrateMonitor.ReadTimeout = 1;
        }
    }

    //Update is called once per frame
    void Update()
    {
        //If heartrate monitor is active
        if (active)
        {
            try
            {
                //Parse string read in from Arduino to integer to use in AI systems
                //BPM will default to 0 if no heartrate is detected
                BPM = int.Parse(arduinoHeartrateMonitor.ReadLine());
            }
            catch (System.Exception)
            {
            }

            //If no heartrate is detected
            if (BPM == 0)
            {
                //Show warning and disable input
                noBPMText.gameObject.SetActive(true);
            }
            //If a heartrate is detected
            else
            {
                //Remove warning and re-enable input
                noBPMText.gameObject.SetActive(false);
            }
        }
    }
}