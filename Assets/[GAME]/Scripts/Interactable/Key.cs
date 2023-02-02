using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 rotationInHand;
    [SerializeField] private Vector3 positionInHand;
    [SerializeField] private float takeTime;
    
    public void Interact(Transform transform)
    {
        if (!PlayerScript.Instance.keyGrabbed)
        {
            PlayerScript.Instance.keyGrabbed = true;
            var hand = PlayerScript.Instance.hand;
            this.transform.parent = hand;
            this.transform.DOLocalRotate(rotationInHand, takeTime).SetEase(Ease.Linear);
            this.transform.DOLocalMove(positionInHand,takeTime).SetEase(Ease.Linear);
        }
    }
}