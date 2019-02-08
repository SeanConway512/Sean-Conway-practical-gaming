using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableConsole : Interactable {
    private bool IsOn = false;
    public override void onInteract()
    {
        InteractText = "Press E to ";
        IsOn = !IsOn;
        
    }
}
