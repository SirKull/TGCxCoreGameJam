using UnityEngine;
using UnityEngine.Events;

public class Trigger_Interact : MonoBehaviour
{
    public Player_Interact playerInteract;

    public bool canInteract;

    public UnityEvent triggerEvent = new UnityEvent();

    private void Start()
    {
        playerInteract = FindAnyObjectByType<Player_Interact>();
        playerInteract.interactEvent.AddListener(Interact);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Interact()
    {
        if (canInteract)
        {
            triggerEvent?.Invoke();
        }
    }
}
