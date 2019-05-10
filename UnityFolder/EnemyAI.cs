using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    private NavMeshAgent agent;
    Transform PlayerPrefs;
    public Transform[] points;
    float movementSpeed = 50f;
    private int distance = 25;
    private GameObject player;
    private int destpoint = 0;
    public float SightDistance = 10;

     void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    // Use this for initialization
    void Start () {
        PlayerPrefs = GameObject.Find("Player").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
       
           /* if (agent != null)
            {
                agent.SetDestination(PlayerPrefs.position);
            }*/
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
        
    }
    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destpoint].position;

        destpoint = (destpoint + 1) % points.Length;
    }
}

