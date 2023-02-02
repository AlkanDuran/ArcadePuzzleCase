using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerJoystickMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private JoystickMonitor joystick;
    public float speed;
    public float rotationSpeed;
    [SerializeField] private Transform _camera;
    public bool IsMove;
    
    public bool joystickActive;

    public Rigidbody playerRigidbody;
    private float startYPos;

    private void Start() 
    {
        startYPos= transform.position.y-.5f;
    }
    
    void FixedUpdate()
    {
        if(joystick.GetHorizontal != 0 || joystick.GetVertical != 0)
        { 
            animator.SetBool("Run",true);
            IsMove=true;
            joystickActive = true;
        }
        else 
        {
            joystickActive = false;
            IsMove=false;
            animator.SetBool("Run",false);
        }
        Vector3 movementDirection = new Vector3(joystick.GetHorizontal,0f, joystick.GetVertical);
        movementDirection.Normalize();

        playerRigidbody.velocity=movementDirection*speed+(Vector3.up*playerRigidbody.velocity.y);
        movementDirection.y=0;
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);            
        }
      
        if(startYPos>transform.position.y)
        {
            animator.SetBool("Fall",true);
            if(transform.position.y<-20) PlayerScript.Instance.Death(true);
        }
    }

    
    
    
}