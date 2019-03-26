using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public GameObject targetPicker;
    public GameObject winningScreen;
    public GameObject losingScreen;
    int tempMax = 0;
    GameObject winningPlayer;
    public List<GameObject> players;
    float targetPickerTimer;
    float chaseTargetTimer;
    float idleTimer;
    bool targetPicked = false;
    bool idleTime = false;
    public bool targetCaught = false;

    float gameSessionTimer = 0.0f;
    

	void Start ()
    {
        targetPickerTimer = Time.time;
        gameSessionTimer = Time.time;
	}
	
	
	void Update ()
    {
        if (Time.time - targetPickerTimer >= 3.0f && !targetPicked)
        {

            targetPicker.GetComponentInParent<TargetPicker>().PickTarget();
            targetPicked = true;
            chaseTargetTimer = Time.time;
            idleTime = false;
            //Debug.Log("Chase Phase Begin");


        }

        else if (targetPicked)
        {
            if ((Time.time - chaseTargetTimer >= 10.0f || targetCaught)&& !idleTime)
            {

                targetPicker.GetComponentInParent<TargetPicker>().IdleTargets();
                idleTimer = Time.time;
                targetCaught = false;
                idleTime = true;
               // Debug.Log("Begin idle phase");

            }

            if(Time.time - idleTimer >= 5.0f && idleTime)
             {
                
              //  Debug.Log("Pick new Target");
                StartPickTarget();
             }
        }

        
        if(Time.time - gameSessionTimer >= 120.0f)
        {

            for (int i = 0; i < players.Count; i++)
            {

                if (tempMax <= players[i].GetComponentInParent<PointSystem>().myPoints)
                {
                    tempMax = players[i].GetComponentInParent<PointSystem>().myPoints;
                    winningPlayer = players[i];
                }
            }

            if(winningPlayer.tag == "Player")
            {
                winningScreen.SetActive(true);
            }
            else
            {
                losingScreen.SetActive(true);
            }
           
            //Time.timeScale = 0.0f;
        }
	}

    public void StartPickTarget()
    {
        targetPicked = false;
        idleTime = false;
        targetPickerTimer = Time.time;
    }
}
