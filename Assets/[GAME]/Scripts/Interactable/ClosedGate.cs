using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedGate : MonoBehaviour,IInteractable
{
    private bool gateOpen;
 
    public void Interact(Transform transform)
    {
        if ( !gateOpen &&  PlayerScript.Instance.big)
        {
            gateOpen = true;
            GetComponent<Animation>().Play("GateOpenAnim");
        }
    }
}
