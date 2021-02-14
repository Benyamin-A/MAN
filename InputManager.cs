using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    //To store the walk speed before running
    private float walkSpeed;
    private Vector2 inputVector;
    public CharacterController controller;
    public void OnSwing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He Swung!");
        }
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He started to aim!");
        }
        else if (context.performed)
        {
            Debug.Log("He's still aiming!");
        }
        else if (context.canceled)
        {
            Debug.Log("He's stopped aiming!");
        }
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He Threw!");
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He started to run!");
        }
        else if (context.performed)
        {
            Debug.Log("He's still running!");
            //switch the speed to sprinting
            speed = this.sprintSpeed;
        }
        else if (context.canceled)
        {
            //switch the speed back to walking
            Debug.Log("He's stopped running!");
            speed = walkSpeed;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He Jumped!");
        }
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("He started to crouch!");
        }
        else if (context.performed)
        {
            Debug.Log("He's still crouching!");
        }
        else if (context.canceled)
        {
            Debug.Log("He's stopped crouching!");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>().ToString());
        inputVector = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        walkSpeed = speed;
    }
    private void Update()
    {
        controller.Move(inputVector * Time.deltaTime * speed);
    }
}
