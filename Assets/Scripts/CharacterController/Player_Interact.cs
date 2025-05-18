using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;

public class Player_Interact : MonoBehaviour
{
    public Player_Input input;

    public UnityEvent interactEvent = new UnityEvent();

    private float interactTimer;
    private float interactCooldown = 0.4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player_Input.interactAction += Interact;
    }

    private void Update()
    {
        if(interactTimer >= 0)
        {
            interactTimer -= Time.deltaTime;   
        }
    }
    private void Interact()
    {
        if(interactTimer < 0)
        {
            Debug.Log("Interact!");
            interactEvent?.Invoke();
            interactTimer = interactCooldown;
        }
    }
}
