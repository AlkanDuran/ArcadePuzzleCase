using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleDecrease : MonoBehaviour, IInteractable
{
    public void Interact(Transform transform)
    {
        PlayerScript.Instance.Smaller();
    }
}
