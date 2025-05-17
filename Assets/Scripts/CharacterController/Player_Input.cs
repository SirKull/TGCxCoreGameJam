using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    public InputSystem_Actions playerActions;

    //player input controls
    public InputAction move;
    private InputAction interact;
    private InputAction crouch;
    private InputAction jump;

    //player actions
    public static Action moveAction;
    public static Action interactAction;
    public static Action crouchAction;
    public static Action jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerActions = new InputSystem_Actions();
        playerActions.Player.Enable();
    }

    private void OnEnable()
    {
        //move player
        move = playerActions.Player.Move;
        move.Enable();

        //player interact
        interact = playerActions.Player.Interact;
        interact.Enable();
        interact.performed += Interact;

        //player crouch
        crouch = playerActions.Player.Crouch;
        crouch.Enable();
        crouch.performed += Crouch;

        //player jump
        jump = playerActions.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
        crouch.Disable();
        jump.Disable();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        interactAction?.Invoke();
    }
    private void Crouch(InputAction.CallbackContext context)
    {
        crouchAction?.Invoke();
    }
    private void Jump(InputAction.CallbackContext context)
    {
        jumpAction?.Invoke();
    }
}
