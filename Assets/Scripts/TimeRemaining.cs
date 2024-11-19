using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemaining : MonoBehaviour
{

    public Text timeRemainingText;
    public float timeLimit = 60f;
    public float timeRemaining;
    public bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        timeRemaining = timeLimit;
        if (timeRemainingText != null)
            timeRemainingText.text = "Time remaining: " + Mathf.FloorToInt(timeRemaining) + " s";
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameEnded){
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0)
            {
                timeRemaining = 0;
            }

            timeRemainingText.text = "Time remaining: " + Mathf.FloorToInt(timeRemaining) + " s";

            if (timeRemaining == 0)
            {
                Debug.Log("Time's up!");
                gameEnded = true;
                KillTracker killTracker = GameObject.FindObjectOfType<KillTracker>();
                killTracker.EndGame();
            }
        }
        
    }
}
