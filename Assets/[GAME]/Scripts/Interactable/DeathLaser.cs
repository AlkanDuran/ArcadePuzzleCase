using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DeathLaser : MonoBehaviour ,IInteractable
{
    private bool gameOver;
    [SerializeField] private PlayerJoystickMovement joystick;
    
    public Vector3 axis;
    void Update()
    {
        transform.position += axis * Time.deltaTime;
    }
   
    public void Interact(Transform transform)
    {
        if (!gameOver)
        {
            gameOver = true;
            joystick.enabled = false;
            PlayerScript.Instance.Death(false);
        }
    }
}