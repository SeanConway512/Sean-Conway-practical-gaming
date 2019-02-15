using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;
    private GameObject Player;
    private bool Patrolling = true;
    private NavMeshAgent navComp;
    // Use this for initialization
    void Start()
    {
        currentPoint = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        navComp = this.GetComponent<NavMeshAgent>();
            transform.position = patrolPoints [0].position;
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


