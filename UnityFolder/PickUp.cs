using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(90 * Time.deltaTime, 0.5f, 0.5f);
	}
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
