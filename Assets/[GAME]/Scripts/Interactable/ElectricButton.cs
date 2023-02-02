using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ElectricButton : MonoBehaviour, IInteractable
{
    private bool doorOpen;
    [SerializeField] private List<Material> matList;
    [SerializeField] private Transform doorTransform;
    
    public void Interact(Transform transform)
    {
        if ( PlayerScript.Instance.big &&!doorOpen)
        {
            doorOpen = true;
            doorTransform.DOMoveY(-1.35f, 1);
            transform.DOLocalMoveY(.3f, .5f).OnComplete(() =>
            {
                GetComponent<Renderer>().material = matList[1];
            });
        }
    }
}
