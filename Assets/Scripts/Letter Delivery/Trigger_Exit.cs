using UnityEngine;
using UnityEngine.Events;

public class Trigger_Exit : MonoBehaviour
{
    public Level_Manager manager;
    private bool triggered;

    public UnityEvent interactEvent = new UnityEvent();

    private void Start()
    {
        manager = FindAnyObjectByType<Level_Manager>();
        Player_Input.interactAction += Interact;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
        }
    }

    private void Interact()
    {
        if (triggered)
        {
            StartCoroutine(manager.ExitScene());
        }
    }
}
