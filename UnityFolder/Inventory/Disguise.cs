using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disguise : Item
{
    public Disguise(string Name):base(Name, "Disguise")
    {
      
    }


    public void crackle()
    {
        Debug.Log("crackle");
    }
    // Use this for initialization

}
