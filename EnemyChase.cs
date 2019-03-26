using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject target;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(target.transform.position);
        }	
	}

    private void OnEnable()
    {
        agent.speed = 3.5f;
        
    }

   
}
