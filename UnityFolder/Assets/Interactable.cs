using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
   
   // public Text InteractText;
    private bool CanInteract = false;
    private int distance = 2;
    private GameObject player;

    // Use this for initialization
    void Start() {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(getPlayer());
    }

    // Update is called once per frame
    void Update() {
       // var dist : float = Vector3.Distance(player.position, transform.position);
        interact();
    }
    public void interact()
    {
        if (distance<=2f)
        {
            CanInteract = true;

            Renderer rend = GetComponent<Renderer>();

            rend.material.color = Color.green;

           // InteractText.text = "Press E to interact";

            if (Input.GetKey(KeyCode.E))
                {
                rend.material.color = Color.yellow;
                MaterialPropertyBlock console = new MaterialPropertyBlock();
                console.AddColor("_Color",Color.yellow);    
                GetComponent<Renderer>().SetPropertyBlock(console);
                }

            
        }
    }
    IEnumerator getPlayer()
    {
        yield return new WaitForSeconds(1f);
        player = GameObject.FindGameObjectWithTag("Player");
    } 
}
