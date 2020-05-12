using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for playing the relevant jumpscare when the player collides with a jumpscare trigger
//This script will be attached to a trigger prefab in the scene and will either play the relevant jumpscare based on the jump scare ID
//or do nothing if the player is already too scared based on their current emotional state or crisp fuzzy output

public class playJumpscare : MonoBehaviour
{
    //Reference to state machine to check if active
    public affectiveAIStateMachine stateMachine;

    //Reference to fuzzy logic to check if active
    public affectiveAIFuzzyLogic fuzzy;

    //Reference to game alter to obtain jump scare logic
    public affectiveAIGameAlter gameAlter;

    //ID which will determine which jumpscare is played
    public int jumpScareID = 0;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    //If object enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        //If object is the player
        if (other.tag == "Player")
        {
            //If state machine is active
            if (stateMachine.active)
            {
                //If state is not scared or very scared (ie player is not scared already)
                if (stateMachine.emotionalState != affectiveAIStateMachine.EmotionalState.Scared &&
                    stateMachine.emotionalState != affectiveAIStateMachine.EmotionalState.VeryScared)
                {
                    //Play jumpscare and destroy trigger
                    callJumpscare();
                    Destroy(gameObject);
                }
            }

            //If fuzzy logic is active
            if (fuzzy.active)
            {
                //If fuzzy crisp output is below certain value (ie player is not scared already)
                if (fuzzy.crispOutput < 70.0f)
                {
                    //Play jumpscare and destroy trigger
                    callJumpscare();
                    Destroy(gameObject);
                }
            }
        }
    }

    //Call relevant jumpscare from game alter based on jumpscare ID
    void callJumpscare()
    {
        switch (jumpScareID)
        {
            //ID 1
            case 1:
                gameAlter.FlashlightFlicker();
                break;

            //ID 2
            case 2:
                gameAlter.LightsJumpscare();
                break;

            //ID 3
            case 3:
                gameAlter.SpotlightJumpscare();
                break;

            //ID 4
            case 4:
                gameAlter.LaunchTrolleyJumpscare();
                break;

            //ID 5
            case 5:
                gameAlter.LaunchChairJumpscare();
                break;

            //ID 6
            case 6:
                gameAlter.LaunchDoorJumpscare();
                break;

            //Default (do nothing, this should never be called)
            default:
                break;
        }
    }
}