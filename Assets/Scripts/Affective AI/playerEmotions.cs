using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;

public class playerEmotions : ImageResultsListener
{
    public float currentFear;
    public float currentEngagement;
    public float currentInnerBrowRaise;
    public float currentBrowRaise;
    public float currentMouthOpen;
    public float currentEyeClosure;
    public float currentAttention;

    public override void onFaceFound(float timestamp, int faceId)
    {
        if (Debug.isDebugBuild) Debug.Log("Found the face");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        currentFear = 0;
        currentEngagement = 0;
        currentInnerBrowRaise = 0;
        currentBrowRaise = 0;
        currentMouthOpen = 0;
        currentEyeClosure = 0;
        currentAttention = 0;

        if (Debug.isDebugBuild) Debug.Log("Lost the face");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue(Emotions.Fear, out currentFear);
            faces[0].Emotions.TryGetValue(Emotions.Engagement, out currentEngagement);
            faces[0].Expressions.TryGetValue(Expressions.InnerBrowRaise, out currentInnerBrowRaise);
            faces[0].Expressions.TryGetValue(Expressions.BrowRaise, out currentBrowRaise);
            faces[0].Expressions.TryGetValue(Expressions.MouthOpen, out currentMouthOpen);
            faces[0].Expressions.TryGetValue(Expressions.EyeClosure, out currentEyeClosure);
            faces[0].Expressions.TryGetValue(Expressions.Attention, out currentAttention);
        }
    }
}
