using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunAway : MonoBehaviour {

    public List<GameObject> challengers;
    Vector3 direction;
    GameObject closestChallenger;
    float closestPosition = 100f;
    float temptClosPos;
    public NavMeshAgent agent;

    float UpdateRunPointTimer;
    public float MaxRunPointTimer;
    bool hasUpdatedRunPoint = true;

    public bool moveAwayFromWall = false;
    float movingAwayTimer;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponentInChildren<MeshRenderer>().enabled)
        {
            agent.speed = 6.5f;
        }

        for (int i = 0; i < challengers.Count; i++)
        {
            temptClosPos = Vector3.Distance(transform.position, challengers[i].transform.position);
            if (temptClosPos < closestPosition)
            {
                closestPosition = temptClosPos;
                closestChallenger = challengers[i];
            }
        }

        if (hasUpdatedRunPoint)
        {
           
            updateRunPoint(transform.position - closestChallenger.transform.position);
            hasUpdatedRunPoint = false;
           
        }
        else if (!hasUpdatedRunPoint && Time.time - UpdateRunPointTimer >= MaxRunPointTimer)
        {
            
           updateRunPoint(transform.position - closestChallenger.transform.position);


        }
       
        agent.SetDestination(direction);


        /*

        if (!moveAwayFromWall)
        {
            direction = transform.position - closestChallenger.transform.position;
            direction = Vector3.Normalize(direction);
            
            transform.Translate(direction * Time.deltaTime);
        }
        else
        {
            if (Random.Range(1, 3) == 1)
            {
                direction = Quaternion.Euler(0, 135, 0) * direction;
            }
            else
            {
                direction = Quaternion.Euler(0, 225, 0) * direction;
            }
            
            transform.Translate( direction * Time.deltaTime);

            if (!movingAway)
            {
                movingAway = true;
                movingAwayTimer = Time.time;

            }
            if(Time.time - movingAwayTimer <= 2.0f)
            {
                movingAway = false;
                moveAwayFromWall = false;
            }
            
        }
    */
	}

    void OnDisable()
    {
        closestPosition = 100f;
        hasUpdatedRunPoint = true;
        agent.speed = 3.5f;
    }

    void avoidWall(Vector3 direction)
    {
        moveAwayFromWall = true;
    }
    void OnEnable()
    {
        if (GetComponentInChildren<MeshRenderer>().enabled)
        {
            agent.speed = 6.5f;
        }
       
    }

    public void updateRunPoint(Vector3 direct)
    {
        
        direct = Vector3.Normalize(direct);
        direct = direct * 10;
        
            direct = Quaternion.Euler(0, Random.Range(-50, 50),0) * direct;
      
        

        UpdateRunPointTimer = Time.time;

        direction = direct;
       
    }
}
