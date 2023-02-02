using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Battery : MonoBehaviour, IInteractable
{
    public void Interact(Transform transform)
    {
        this.transform.GetComponent<Collider>().enabled = false;
        PlayerScript.Instance.CollectBattery(this.transform);
        this.transform.DOLocalMove(Vector3.zero, .3f);
        this.transform.DOLocalRotate(Vector3.zero, .3f);
    }
}
