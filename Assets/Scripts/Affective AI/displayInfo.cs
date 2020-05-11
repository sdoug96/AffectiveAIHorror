using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will take the more important values from various different scripts and display them on the screen during gameplay
//This is purely for demo purposes and will not be shown to the player in order for them not to get distracted, focus on the game
//and heighten immersion with no HUD (heads up display)

public class displayInfo : MonoBehaviour
{
    //Set to true for demo to display values
    public bool demo = false;

    //Heartrate beats per min variables
    public heartRateMonitor HRM;
    private int BPM;
    public Text BPMText;

    //Fuzzy variables
    public affectiveAIFuzzyLogic fuzzy;
    private float fuzzyOutput;

    //State machine variables
    public affectiveAIStateMachine stateMachine;

    //Text variables
    public Text stateOrFuzzyOutput;
    public Text AIActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If fuzzy logic is active
        if (fuzzy.active)
        {
            //Set and display heartrate beats per min
            BPM = HRM.BPM;
            BPMText.text = "BPM: " + BPM;

            //Set and display fuzzy crisp output
            fuzzyOutput = fuzzy.crispOutput;
            stateOrFuzzyOutput.text = "CRISP FUZZY OUTPUT: " + fuzzyOutput;

            //Display fuzzy logic is active
            AIActive.text = "FUZZY LOGIC";
        }
        //If state machine is active
        else if (stateMachine.active)
        {
            //Set and display heartrate beats per min
            BPM = HRM.BPM;
            BPMText.text = "BPM: " + BPM;

            //Display current emotional state
            stateOrFuzzyOutput.text = "CURRENT STATE: " + stateMachine.emotionalState.ToString();

            //Display state machine is active
            AIActive.text = "AI ACTIVE: STATE MACHINE";
        }
        //If no AI is active
        else
        {
            //Display no AI is active
            BPMText.text = "";
            stateOrFuzzyOutput.text = "";
            AIActive.text = "AI ACTIVE: NONE";
        }

        //If this is not a demo
        if (!demo)
        {
            //Do not display any text
            BPMText.text = "";
            stateOrFuzzyOutput.text = "";
            AIActive.text = "";
        }
    }
}