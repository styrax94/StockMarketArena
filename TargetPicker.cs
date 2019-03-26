using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetPicker : MonoBehaviour {


  
    public List<GameObject> targets;
    GameObject challengers;
    private int previousTarget = 10;
    bool checkTarget = false;
    
    void Update()
    {
        if (checkTarget)
        {


        }

    }
    public void PickTarget()
    {
        int priorityTarget = getRandomNumber(targets.Count);
        
      
        for (int i =0; i < targets.Count; i++)
        {
            if(i == priorityTarget)
            {
               
                if (targets[i].tag == "Enemy")
                {
                    
                    targets[i].GetComponentInParent<EnemyRunAway>().enabled = true;
                    targets[i].GetComponentInParent<EnemyChase>().enabled = false;
                }
                targets[i].GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            else
            {
                if (targets[i].tag == "Enemy")
                {
                    
                    targets[i].GetComponentInParent<EnemyRunAway>().enabled = false;
                    targets[i].GetComponentInParent<EnemyChase>().enabled = true;
                    targets[i].GetComponentInParent<EnemyChase>().target = targets[priorityTarget];

                }
                targets[i].GetComponentInChildren<MeshRenderer>().enabled = false;

            }

            
        }

        checkTarget = true;
    }

    public void IdleTargets()
    {
        targets[previousTarget].GetComponentInChildren<MeshRenderer>().enabled = false;
        checkTarget = false;
        Debug.Log("Begin Idle Phase");
        for (int i = 0; i < targets.Count; i++)
        {

            if (targets[i].tag == "Enemy")
            {
                targets[i].GetComponentInParent<EnemyRunAway>().enabled = true;
                targets[i].GetComponentInParent<EnemyChase>().enabled = false;
            }

        }
    }

    private int getRandomNumber(int size)
    {
        bool randomRecieved = false;
        int randomIntTarget = 0;
       

        while (!randomRecieved)
        {
            randomIntTarget = (Random.Range(0, size));
            if(randomIntTarget == size)
            {
                randomIntTarget -= 1;
            }
            
            
            if(randomIntTarget != previousTarget)
            {
                previousTarget = randomIntTarget;
                randomRecieved = true;
            }

        }

        return randomIntTarget;

    }
}
