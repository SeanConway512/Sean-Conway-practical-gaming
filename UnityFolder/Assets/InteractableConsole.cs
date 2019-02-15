using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableConsole : Interactable {
    private bool IsOn = false;
    public void onInteract()
    {
        //InteractText = "Press E to ";
        IsOn = !IsOn;
       
    }
}
