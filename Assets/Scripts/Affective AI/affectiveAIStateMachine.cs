using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affectiveAIStateMachine : MonoBehaviour
{
    public playerEmotions emotions;
    public heartRateMonitor HRM;

    enum EmotionalState
    {
        Neutral,
        Disengaged,
        Bored,
        Scared
    };

    //Emotional state variable
    EmotionalState emotionalState;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise emotional state to neutral
        emotionalState = EmotionalState.Neutral;
    }

    // Update is called once per frame
    void Update()
    {
        //Run the state machine
        StateMachineLogic();
    }

    void StateMachineLogic()
    {
        //If the player's heart rate is above 80 and current fear is above 0.5
        if ((HRM.testBPM > 80) && (emotions.currentFear > 0.5f) && (emotions.currentAttention > 0.75f))
        {
            //Change emotional state to scared
            emotionalState = EmotionalState.Scared;
        }
        //If the player's heart rate is lower than 80, fear is less than 0.5 but attention is still higher than 0.75
        else if((HRM.testBPM < 80) && (emotions.currentFear < 0.5f) && (emotions.currentAttention > 0.75f))
        {
            //Change emotional state to bored
            emotionalState = EmotionalState.Bored;
        }
        //If the player's attention is lower than 0.75
        else if(emotions.currentAttention < 0.75f)
        {
            //Change emotional state to disengaged
            emotionalState = EmotionalState.Disengaged;
        }
    }
}