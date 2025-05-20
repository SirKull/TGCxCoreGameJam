using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    public Player_Actions playerActions;

    //player input controls
    public InputAction move;
    private InputAction interact;
    private InputAction crouch;
    private InputAction jump;
    private InputAction glide;

    //player actions
    public static Action interactAction;
    public static Action crouchAction;
    public static Action standAction;
    public static Action jumpAction;
    public static Action glideAction;
    public static Action glideStopAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerActions = new Player_Actions();
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

        //player glide
        glide = playerActions.Player.Glide;
        glide.Enable();
        glide.performed += Glide;
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
        if (playerActions.Player.Crouch.WasPressedThisFrame())
        {
            crouchAction?.Invoke();
        }
        if (playerActions.Player.Crouch.WasReleasedThisFrame())
        {
            standAction?.Invoke();
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        jumpAction?.Invoke();
    }

    private void Glide(InputAction.CallbackContext context)
    {
        if (playerActions.Player.Glide.WasPressedThisFrame())
        {
            glideAction?.Invoke();
        }
        if (playerActions.Player.Glide.WasReleasedThisFrame())
        {
            glideStopAction?.Invoke();
        }
    }
}
