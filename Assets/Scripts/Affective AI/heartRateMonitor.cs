using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class heartRateMonitor : MonoBehaviour
{
    SerialPort arduinoHeartrateMonitor;

    //Bool to turn the heartrate monitor on or off
    public bool active = true;

    //Beats per minute variable
    public int BPM = 60;

    //Test value whilst getting Arduino value reading properly
    public int testBPM = 75;

    //Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            //Intialise heart rate monitor from Arduino IDE
            arduinoHeartrateMonitor = new SerialPort("COM5", 115200);

            arduinoHeartrateMonitor.Open();
            arduinoHeartrateMonitor.ReadTimeout = 1;
        }
    }

    //Update is called once per frame
    void Update()
    {
        //Debug.Log(testBPM);

        if (active)
        {
            try
            {
                //This will take the heart rate data read in as a string and convert it to an integer
                int.TryParse(arduinoHeartrateMonitor.ReadLine(), out BPM);
            }
            catch (System.Exception)
            {
            }
        }
    }
}