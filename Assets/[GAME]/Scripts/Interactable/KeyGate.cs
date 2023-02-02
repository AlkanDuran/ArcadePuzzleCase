using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KeyGate : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform keyHolder;
    private bool doorOpen;
    public void Interact(Transform transform)
    {
        if (PlayerScript.Instance.keyGrabbed && !doorOpen)
        {
            doorOpen = true;
            var key=PlayerScript.Instance.hand.GetChild(1);
            key.parent = null;
            key.DOMove(keyHolder.position, .5f);
            key.DORotate(keyHolder.rotation.eulerAngles, .5f).OnComplete(() =>
            {
                key.DORotate(Vector3.forward * 360, 2).OnComplete(() =>
                {
                    key.DOScale(Vector3.zero, .5f).OnComplete(() =>
                    {
                        this.transform.DOMoveY(-1.25f, 1f).SetEase(Ease.Linear);
                    });
                });
            });
        }
    }
}
