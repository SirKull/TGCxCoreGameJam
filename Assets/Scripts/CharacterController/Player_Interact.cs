using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Player_Interact : MonoBehaviour
{
    public Player_Input input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player_Input.interactAction += Interact;
    }
    private void Interact()
    {
        Debug.Log("Interact!");
    }
}
