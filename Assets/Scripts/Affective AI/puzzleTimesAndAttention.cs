using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for recording how long it took the player to complete each puzzle and how focused they were during each playthrough
//It does this with an incrementing timer and resetting this timer each time the end door of a puzzle is opened
//The players attention value is recorded every 2 seconds and an average taken at the end
//The timer and attention values will only increment when a face and heartbeat are detected by the application

public class puzzleTimesAndAttention : MonoBehaviour
{
    //References
    public playerMovement movement;
    public mouseLook look;
    public playerEmotions emotions;

    //Timer used to record puzzle times
    public float timer = 0.0f;

    //Times taken to complete puzzles
    public float puzzle1Time = 0.0f, puzzle2Time = 0.0f, puzzle3Time = 0.0f;

    //List of attention values
    List<float> attentionValues = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        //Add attention value every two seconds
        InvokeRepeating("AddAttentionValue", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //If input is not disabled
        if (movement.canMove && look.canLook)
        {
            //Increment timer
            timer += Time.deltaTime;
        }
    }

    void AddAttentionValue()
    {
        //If input is not disabled
        if (movement.canMove && look.canLook)
        {
            //Add current attention value to list of attention values
            attentionValues.Add(emotions.currentAttention);
        }
    }

    private void OnApplicationQuit()
    {
        //Total attention value
        float totalAttentionValue = 0.0f;

        //Final average attention value
        float avgAttentionValue = 0.0f;

        //Add all attention values
        for (int i = 0; i < attentionValues.Count; i++)
        {
            totalAttentionValue += attentionValues[i];
        }

        //Calculate average attention value
        avgAttentionValue = totalAttentionValue / attentionValues.Count;

        //Round values to 2 decimal places
        puzzle1Time = Mathf.Round(puzzle1Time * 100f) / 100f;
        puzzle2Time = Mathf.Round(puzzle2Time * 100f) / 100f;
        puzzle3Time = Mathf.Round(puzzle3Time * 100f) / 100f;
        avgAttentionValue = Mathf.Round(avgAttentionValue * 100f) / 100f;

        //Print values
        Debug.Log("Time taken to complete puzzle 1: " + puzzle1Time + " seconds");
        Debug.Log("Time taken to complete puzzle 2: " + puzzle2Time + " seconds");
        Debug.Log("Time taken to complete puzzle 3: " + puzzle3Time + " seconds");
        Debug.Log("Average attention value: " + avgAttentionValue);
    }
}