﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{

       public float fieldOfViewAngle = 110f;
       public bool playerInSight;
       public Vector3 personalLastSighting;

       private NavMeshAgent nav;
       private SphereCollider col;
       private Animator anim;
       private LastPlayerSighting lastPlayerSighting;
       private GameObject Player;
       private Animator playerAnim;
       private Vector3 previousSighting;

       private void Awake()
       {
           nav = GetComponent<NavMeshAgent>();
           col = GetComponent<SphereCollider>();
           anim = GetComponent<Animator>();

           player = GameObject.FindGameObjectWithTag(Tags.player);
           playerAnim = player.GetComponent<Animator>();

           previousSighting = lastPlayerSighting.resetPosition;
   }

       // Use this for initialization
       void Start () {

       }

       // Update is called once per frame
       void Update () {
           if (lastPlayerSighting.position != previousSighting)
               personalLastSighting = lastPlayerSighting.position;

           previousSighting = lastPlayerSighting.position;

       }
       private void OnTriggerStay(Collider other)
       {
           if(other.gameObject== Player)
           {
               playerInSight = false;

               Vector3 direction = other.transform.position - transform.position;
               float angle = Vector3.Angle(direction, transform.forward);

               if(angle < fieldOfViewAngle * 0.5f)
               {
                   RaycastHit hit;

                   if(Physics.Raycast(transform.position + transform.up, direction.normalized,out hit, col.radius))
                   {
                       if(hit.collider.gameObject == Player)
                       {
                           playerInSight = true;
                           lastPlayerSighting.position = Player.transform.position;
                       }
                   }
               }

           }
           void OnTriggerExit(Collider other)
        {
            if(other.gameObject ==Player)
        }


           float CalculatePathLength(Vector3 targetPosition)
           {
               NavMeshPath path = new NavMeshPath();

               if (nav.enabled)
                   nav.CalculatePath(targetPosition, path);

               Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

               allWayPoints[0] = transform.position;
               allWayPoints[allWayPoints.Length-1] =targetPosition;

              for(int i=0; i<path.corners.Length; i++)
            {
                allWayPoints[i + 1] = path.corners[i];
            }
            float pathLength = 0f;

            for(int i=0; i<allWayPoints.Length-1; i++)
           {
                pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
           }
            return pathLength;
       }
   
}
