using System.Collections;
using System.Collections.Generic;
using FLS; // https://github.com/davidgrupp/Fuzzy-Logic-Sharp
using FLS.Rules;
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
    public double crispOutput = 1.0f;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if (active)
        {
            //Setup the heartrate input for FIS
            var heartrate = new LinguisticVariable("Heartrate");
            var veryHighH = heartrate.MembershipFunctions.AddTrapezoid("VeryHighH", 120.0f, 140.0f, 160.0f, 160.0f);
            var highH = heartrate.MembershipFunctions.AddTriangle("HighH", 100.0f, 120.0f, 140.0f);
            var averageH = heartrate.MembershipFunctions.AddTriangle("AverageH", 60.0f, 80.0f, 100.0f);
            var lowH = heartrate.MembershipFunctions.AddTriangle("LowH", 20.0f, 40.0f, 60.0f);
            var veryLowH = heartrate.MembershipFunctions.AddTrapezoid("VeryLowH", 0.0f, 0.0f, 20.0f, 40.0f);

            //Setup the attention input for FIS
            var attention = new LinguisticVariable("Attention");
            var highA = attention.MembershipFunctions.AddTriangle("HighA", 50.0f, 75.0f, 100.0f);
            var averageA = attention.MembershipFunctions.AddTriangle("AverageA", 25.0f, 50.0f, 75.0f);
            var lowA = attention.MembershipFunctions.AddTriangle ("LowA", 0.0f, 25.0f, 50.0f);

            //Setup the fear output for FIS
            var fear = new LinguisticVariable("Fear");
            var veryHighF = fear.MembershipFunctions.AddTrapezoid("VeryHighF", 70.0f, 90.0f, 100.0f, 100.0f);
            var highF = fear.MembershipFunctions.AddTriangle("HighF", 50.0f, 70.0f, 90.0f);
            var averageF = fear.MembershipFunctions.AddTriangle("AverageF", 30.0f, 50.0f, 70.0f);
            var lowF = fear.MembershipFunctions.AddTriangle("LowF", 10.0f, 30.0f, 50.0f);
            var veryLowF = fear.MembershipFunctions.AddTrapezoid("VeryLowF", 0.0f, 0.0f, 10.0f, 30.0f);

            //Default defuzzification is CoG
            IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().Default();

            //Rules for very high heart rate
            var rule1 = Rule.If(heartrate.Is(veryHighH).And(attention.Is(highA))).Then(fear.Is(veryHighF));
            var rule2 = Rule.If(heartrate.Is(veryHighH).And(attention.Is(averageA))).Then(fear.Is(highF));
            var rule3 = Rule.If(heartrate.Is(veryHighH).And(attention.Is(lowA))).Then(fear.Is(lowF));

            //Rules for high heart rate
            var rule4 = Rule.If(heartrate.Is(highH).And(attention.Is(highA))).Then(fear.Is(highF));
            var rule5 = Rule.If(heartrate.Is(highH).And(attention.Is(averageA))).Then(fear.Is(averageF));
            var rule6 = Rule.If(heartrate.Is(highH).And(attention.Is(lowA))).Then(fear.Is(lowF));

            //Rules for average heart rate
            var rule7 = Rule.If(heartrate.Is(averageH).And(attention.Is(highA))).Then(fear.Is(averageF));
            var rule8 = Rule.If(heartrate.Is(averageH).And(attention.Is(averageA))).Then(fear.Is(lowF));
            var rule9 = Rule.If(heartrate.Is(averageH).And(attention.Is(lowA))).Then(fear.Is(lowF));

            //Rules for low heart rate
            var rule10 = Rule.If(heartrate.Is(lowH).And(attention.Is(highA))).Then(fear.Is(lowF));
            var rule11 = Rule.If(heartrate.Is(lowH).And(attention.Is(averageA))).Then(fear.Is(veryLowF));
            var rule12 = Rule.If(heartrate.Is(lowH).And(attention.Is(lowA))).Then(fear.Is(lowF));

            //Rules for very low heart rate
            var rule13 = Rule.If(heartrate.Is(veryLowH).And(attention.Is(highA))).Then(fear.Is(veryLowF));
            var rule14 = Rule.If(heartrate.Is(veryLowH).And(attention.Is(averageA))).Then(fear.Is(veryLowF));
            var rule15 = Rule.If(heartrate.Is(veryLowH).And(attention.Is(lowA))).Then(fear.Is(veryLowF));

            //Add rules to fuzzy engine
            fuzzyEngine.Rules.Add(rule1, rule2, rule3, rule4, rule5, rule6, rule7, rule8, rule9, rule10, rule11, rule12, rule13, rule14, rule15);

            //Set a value to the defuzzified output
            double result = fuzzyEngine.Defuzzify(new { heartrate = (double)HRM.BPM, attention = (double)emotions.currentAttention });

            //Set the crisp output to the defuzzified result
            crispOutput = result;
        }
    }
}