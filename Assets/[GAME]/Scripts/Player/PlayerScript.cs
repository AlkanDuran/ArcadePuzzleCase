using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviourSingleton<PlayerScript>
{
    public PlayerJoystickMovement playerJoystickMovement;

    public bool big, small, standart=true;
    public Transform hand;
    [HideInInspector] public bool keyGrabbed;

    public List<Transform> collectedBatterys;
    public List<Transform> seats;
    public int filledSeatCount;
    public void Bigger()
    {
        if(big) return;
        if(standart) 
        {
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f);
            big = true;
            standart = false;
            return;
        }
        if(small)
        {
            transform.DOScale(Vector3.one, 1f);
            small = false;
            standart = true;
        }
    }

    public void Smaller()
    {
        if(small) return;
        if(standart) 
        {
            transform.DOScale(new Vector3(.5f, .5f, .5f), 1f);
            small = true;
            standart = false;
            return;
        }
        if(big)
        {
            transform.DOScale(Vector3.one, 1f);
            standart = true;
            big = false;
        }
    }

    public void Death(bool fall)
    {
        playerJoystickMovement.enabled = false;
        GameManager.Instance.levelFailPanel.transform.DOScale(Vector3.one, 1f);
        if (fall)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        GetComponent<Animator>().SetBool("Death",true);
    }
    

    public void CollectBattery(Transform batteryTransform)
    {
        batteryTransform.parent = seats[filledSeatCount];
        filledSeatCount++;
        collectedBatterys.Add(batteryTransform);
    }
}