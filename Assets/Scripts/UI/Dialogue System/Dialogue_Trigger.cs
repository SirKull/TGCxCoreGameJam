using UnityEngine;
using UnityEngine.Events;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;   
    public Player_Interact playerInteract;

    public bool canInteract;

    public UnityEvent interactEvent = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            playerInteract = other.GetComponent<Player_Interact>();
            playerInteract.interactEvent.AddListener(Interact);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            if (dialogue.dialogueStarted)
            {
                dialogue.ExitDialogue();
            }
        }
    }

    private void Interact()
    {
        if (canInteract)
        {
            if (!dialogue.dialogueStarted)
            {
                dialogue.StartDialogue();
            }
            else
            {
                dialogue.OnClick();
            }
        }
    }
}
