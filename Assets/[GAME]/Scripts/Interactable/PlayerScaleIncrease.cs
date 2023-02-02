using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleIncrease : MonoBehaviour, IInteractable
{
    public void Interact(Transform transform)
    {
        PlayerScript.Instance.Bigger();
    }
}
