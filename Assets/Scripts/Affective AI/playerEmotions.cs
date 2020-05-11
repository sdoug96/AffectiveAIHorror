using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;

//This script is largely taken from Forest Handfords Affectiva tutorial
//He states that the user can chose to implement their own emotions script with specific behaviour if needed
//However, for this project, this implementation with the emotions and expressions that were needed was fine

public class playerEmotions : ImageResultsListener
{
    //Bool to turn facial recognition on or off
    public bool active = false;

    //Bool to check if face is in view
    public bool faceInView = true;

    //Warning to show player if face is lost
    public Text faceLostText;

    //Emotion and expression values which can be accessed by other scripts
    public float currentAttention;

    //This function is called when the face has been found by the camera
    public override void onFaceFound(float timestamp, int faceId)
    {
        //If Affectiva plugin is active
        if (active)
        {
            //Remove warning and re-enable input
            faceLostText.gameObject.SetActive(false);
            faceInView = true;
        }
    }

    //This function is called when the face has been lost from view of the camera
    public override void onFaceLost(float timestamp, int faceId)
    {
        //If Affectiva plugin is active
        if (active)
        {
            //Set values to 0
            currentAttention = 0.0f;

            //Show warning and disable input
            faceLostText.gameObject.SetActive(true);
            faceInView = false;
        }
    }

    //This function is called when an image is detected by the camera
    public override void onImageResults(Dictionary<int, Face> faces)
    {
        //If Affective plugin is active
        if (active)
        {
            //If a face is found
            if (faces.Count > 0)
            {
                //Get values from player's face
                faces[0].Expressions.TryGetValue(Expressions.Attention, out currentAttention);
            }
        }
    }
}
