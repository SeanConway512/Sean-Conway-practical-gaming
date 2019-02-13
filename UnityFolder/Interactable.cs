using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public string Name;
    public string InteractText = "press E to interact";
    private bool CanInteract = false;
    private int distance = 2;
    public GameObject player;
   
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
        
     
	}
	
	// Update is called once per frame
	void Update () {
        interact();
	}
    public void interact()
    {
       // if (Vector3.Distance(player = GameObject.Find("Player").transform.position) > distance)
        {
            if (CanInteract == true)
            {
                Renderer rend = GetComponent<Renderer>();

                rend.material.color = Color.green;

                if (Input.GetKey(KeyCode.E))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        rend.material.color = Color.yellow;
                    }
                }
            }
        }
    }
}
