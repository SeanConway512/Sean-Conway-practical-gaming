using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
   
    private Text InteractText;
    private bool CanInteract = false;
    private int distance = 25;
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
        interact();
    }
    public void interact()
    {
        if (Vector3.Distance(this.transform.position,player.transform.position)<=distance)
        {
            CanInteract = true;

            Renderer rend = GetComponent<Renderer>();

            rend.material.color = Color.green;

            //InteractText.text = "Press E to interact";

            if (CanInteract==true && Input.GetKey(KeyCode.E))
                {
                rend.material.color = Color.yellow;
                MaterialPropertyBlock console = new MaterialPropertyBlock();
                console.SetColor("_Color",Color.yellow);    
                GetComponent<Renderer>().SetPropertyBlock(console);
                }

            
        }
    }
    IEnumerator getPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        player = GameObject.FindGameObjectWithTag("Player");
    } 
}
