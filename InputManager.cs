using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public CharacterController controller;
    
    public float jumpHeight;
    public float gravitySpeed;
    public float maxHeight;

    [SerializeField]
    //To store the walk speed before running and switch back to afterwards
    private float walkSpeed;   
    private Vector2 inputVector;
    private Vector2 verticalVelocityVector;
    private bool jumpPushed;
    private bool facingRight;

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
       if (context.performed)
        {
            if (controller.isGrounded && !jumpPushed)
            {
                jumpPushed = true;
                if (this.transform.position.y<maxHeight)
                {
                    inputVector.y += Mathf.Sqrt(jumpHeight * -3.0f * gravitySpeed);
                }
                
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
        if (context.started)
        {
            if (!facingRight && inputVector.x > 0)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = true;
            }
            if (facingRight && inputVector.x<0)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
            }

        }   
    }

    private void Start()
    {
        walkSpeed = speed;
        facingRight = true;
    }


    private void Update()
    {

        if (controller.isGrounded && inputVector.y<0)
        {
            inputVector.y = 0;
        }

        inputVector.y += gravitySpeed * Time.deltaTime;

        controller.Move(inputVector * speed * Time.deltaTime);
    }

}
