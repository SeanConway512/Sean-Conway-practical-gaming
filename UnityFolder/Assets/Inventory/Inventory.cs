using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    List<Item> Items;
    // Use this for initialization
    void Start () {

        Items = new List<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddTo(Item NewItem)
    {
        Items.Add(NewItem);
    }

    internal Item getItem(int v)
    {
        return Items[v];
    }
}
