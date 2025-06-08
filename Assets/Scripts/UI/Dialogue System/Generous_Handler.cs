using UnityEngine;

public class Generous_Handler : MonoBehaviour
{
    public End_Condition condition;
    public Dialogue dialogue;

    private bool generousTriggered;

    [SerializeField] private bool grandparentGenerous;
    [SerializeField] private bool parentGenerous;
    [SerializeField] private bool harperGenerous;
    [SerializeField] private bool gariGenerous;

    private void Awake()
    {
        generousTriggered = false;
        condition = FindAnyObjectByType<End_Condition>();
        dialogue = GetComponent<Dialogue>();

        dialogue.endDialogueEvent.AddListener(GenerousEvent);
    }

    public void GenerousEvent()
    {
        if (!generousTriggered)
        {
            if (grandparentGenerous)
            {
                condition.grandparentGenerous++;
            }
            if (parentGenerous)
            {
                condition.parentGenerous++;
            }
            if (harperGenerous)
            {
                condition.harperGenerous++;
            }
            if (gariGenerous)
            {
                condition.gariGenerous++;
            }
            generousTriggered = true;
        }
    }
}
