using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affectiveAIFuzzyLogic : MonoBehaviour
{
    //This will control whether or not the state machine is running
    //The game alter script will control which, if any, of the AI systems are running during gameplay
    public bool active = false;

    //Visual and physiological values for fuzzy logic system
    public playerEmotions emotions;
    public heartRateMonitor HRM;

    //The crisp fuzzy output value that will be used to alter the gameplay
    public float crispOutput = 1.0f;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}