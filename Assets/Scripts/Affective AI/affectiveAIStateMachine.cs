using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class affectiveAIStateMachine : MonoBehaviour
{
    //This will control whether or not the state machine is running
    public bool active = false;

    //Visual and physiological values for state machine
    public playerEmotions emotions;
    public heartRateMonitor HRM;

    //Enum of different emotional states
    public enum EmotionalState
    {
        Neutral,
        Disengaged,
        Calm,
        Scared,
        VeryScared
    };

    //Emotional state variable
    public EmotionalState emotionalState;

    //Start is called before the first frame update
    void Start()
    {
        //Initialise emotional state to bored
        emotionalState = EmotionalState.Neutral;
    }

    //Update is called once per frame
    void Update()
    {
        if (active)
        {
            //Run the state machine
            StateMachineLogic();
        }
    }

    void StateMachineLogic()
    {
        //If heartrate is above 120 and attention above 80
        if ((HRM.BPM >= 120) && (emotions.currentAttention >= 80.0f))
        {
            //Player is very scared
            emotionalState = EmotionalState.VeryScared;
        }
        //If heartrate is between 100 and 120 and attention is above 80
        else if((HRM.BPM < 120) && (HRM.BPM > 100) && (emotions.currentAttention >= 80.0f))
        {
            //Player is scared
            emotionalState = EmotionalState.Scared;
        }
        //If heartrate is lower than 100 and attention is above 80
        else if ((HRM.BPM < 100) && (emotions.currentAttention >= 80.0f))
        {
            //Player is calm
            emotionalState = EmotionalState.Calm;
        }
        //If attention is below 80
        else if (emotions.currentAttention < 80.0f)
        {
            //Player is disengaged
            emotionalState = EmotionalState.Disengaged;
        }
        //If no other state conditions are met (should never be called)
        else
        {
            //Default state to neutral
            emotionalState = EmotionalState.Neutral;
        }
    }
}