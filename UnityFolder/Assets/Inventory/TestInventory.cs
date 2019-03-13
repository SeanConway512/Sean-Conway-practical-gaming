using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour {
    Inventory myInventory;


    Disguise a, b;

    Keycard c, d;

	// Use this for initialization
	void Start () {
        myInventory = GetComponent<Inventory>();


        a = new Disguise("Guard");
        b = new Disguise("Nurse");
        c = new Keycard("Red");
        d = new Keycard("blue");


        myInventory.AddTo(a);
        myInventory.AddTo(d);
        myInventory.AddTo(b);
        myInventory.AddTo(c);




        Item randItem = myInventory.getItem((int)UnityEngine.Random.RandomRange(0, 4));


        if (randItem is Keycard) (randItem as Keycard).snapKeyCard();
        if (randItem is Disguise) (randItem as Disguise).crackle();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
