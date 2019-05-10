using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Item
{
    public Keycard(string Name): base(Name,"KeyCard")
    {
    
    }


    public void snapKeyCard()
    {
        Debug.Log("Snap");
    }

}
