using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    NavMeshAgent agent;
    Transform PlayerPrefs;

     void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
        PlayerPrefs = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (agent != null)
        {
            agent.SetDestination(PlayerPrefs.position);
        }
      
    }
}

