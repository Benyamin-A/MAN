using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public CharacterController controller;
    
    public float jumpSpeed;
    public float gravitySpeed;

    [SerializeField]
    //To store the walk speed before running and switch back to afterwards
    private float walkSpeed;   
    private Vector2 inputVector;
    private Vector2 verticalVelocityVector;
    private bool jumpPushed;


    public void OnSwing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He Swung!");
        }
    }

    public void OnAim(InputAction.CallbackContext context)
    {

    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He Threw!");
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {

    }

    public void OnSprint(InputAction.CallbackContext context)
    {
       if (context.performed)
        {
            //switch the speed to sprinting
            speed = this.sprintSpeed;
        }
        else if (context.canceled)
        {
            //switch the speed back to walking
            speed = walkSpeed;
        }
    }






    public void OnJump(InputAction.CallbackContext context)
    {
       if (context.started)
        {
            if (controller.isGrounded && !jumpPushed)
            {
                jumpPushed = true;
               
                //velocity = inputVector * speed;
                //velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
            } 
        }

        if (context.canceled)
        {
            jumpPushed = false;
        }
    }



    public void OnMove(InputAction.CallbackContext context)
    {
       inputVector=context.ReadValue<Vector2>();
        
    }

    private void Start()
    {
        walkSpeed = speed;
    }


    private void Update()
    {
        Vector2 velocityVector;
        if (!controller.isGrounded)
        {
            
        }
        
        controller.Move((inputVector*speed )* Time.deltaTime);
    }

}
