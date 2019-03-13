using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    private Transform[] patrolPoints;
    private float moveSpeed = 10;
    private int currentPoint;
    private GameObject Player;
    private bool Patrolling = true;
    private NavMeshAgent navComp;
   
    private void Awake()
    {
        navComp = this.GetComponent<NavMeshAgent>();
        //transform.position = patrolPoints[20].position;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        currentPoint = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
        float range = Vector3.Distance(transform.position, Player.transform.position);
        
        if (range <= 20)
        {
            Patrolling = false;
        }
        else if (range >= 20)
        {
            Patrolling = true;
        }
        if (Patrolling)
        {
            navComp.enabled = false;
            transform.LookAt(patrolPoints[currentPoint].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            if (transform.position == patrolPoints[currentPoint].position)
            {
                currentPoint++;
            }
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }
        else if (Patrolling == false)
        {
            transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
            navComp.enabled = true;
            navComp.SetDestination(Player.transform.position);

        }
    }

}


