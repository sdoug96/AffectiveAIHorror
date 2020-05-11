using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is responsible for changing the key locations on each playthrough based on an ID which is set before playing
//This means the keys will not always be in the same place with each playthrough, making it very easy for the player to find them again

public class keyLocations : MonoBehaviour
{
    public affectiveAIStateMachine stateMachine;

    public affectiveAIFuzzyLogic fuzzy;

    //Key game objects
    public GameObject[] keys;

    // Start is called before the first frame update
    void Start()
    {
        if (stateMachine.active)
        {
            keys[0].transform.position = new Vector3(-2.433f, 1.369f, 8.828f);
            keys[1].transform.position = new Vector3(7.446f, 2.366f, 99.98f);
            keys[2].transform.position = new Vector3(-22.058f, 2.012f, 154.329f);
        }

        else if (fuzzy.active)
        {
            keys[0].transform.position = new Vector3(-29.536f, 2.041f, 46.906f);
            keys[1].transform.position = new Vector3(9.046f, 0.289f, 79.737f);
            keys[2].transform.position = new Vector3(-5.89f, 1.501f, 161.626f);
        }

        else
        {
            keys[0].transform.position = new Vector3(-28.436f, 1.333f, 38.57292f);
            keys[1].transform.position = new Vector3(19.42f, 1.333f, 85.27f);
            keys[2].transform.position = new Vector3(-32.34f, 1.333f, 129.22f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}