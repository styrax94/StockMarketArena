using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

    // Use this for initialization
    public int myPoints = 0;
	public Text scoreText;
    public GameObject gameManager;
    private Animator _anim;
    private Vector3 old_pos;

    void Start()
    {
       
        _anim = GetComponentInChildren<Animator>();
        old_pos = transform.position;
		scoreText.text = "0";
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponentInChildren<MeshRenderer>().enabled && (other.tag == "Enemy" || other.tag == "Player"))
        {
            Debug.Log("Got Caught");
            gameManager.GetComponentInParent<GameLogic>().targetCaught = true;
            myPoints++;
			scoreText.text = "" + myPoints;
        }
        //else
        //{
        //    _anim.Play("Attack");
        //}
    }

    private void FixedUpdate()
    {

        if(tag != "Player")
        {
            var ApproxPosition = (Mathf.Approximately(old_pos.x, transform.position.x) && Mathf.Approximately(old_pos.y, transform.position.y) && Mathf.Approximately(old_pos.z, transform.position.z));


            if (!ApproxPosition)
            {
                _anim.Play("Walking");
            }
            if (ApproxPosition)
            {
                _anim.Play("Idle");
            }

            old_pos = transform.position;


        }
        
    }
}
