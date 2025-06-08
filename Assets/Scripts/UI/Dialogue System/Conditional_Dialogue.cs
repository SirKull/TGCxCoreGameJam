using System.Collections;
using UnityEngine;

public class Conditional_Dialogue : Dialogue
{
    public Player_Inventory inventory;

    //check if player has object
    [SerializeField] private string neededObject;
    public bool hasObject;

    //lines in dialogue object
    public string[] objectLines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inventory = FindAnyObjectByType<Player_Inventory>();

        for(int i = 0; i< inventory.inventory.Count; i++)
        {
            if (inventory.inventory[i] == neededObject)
            {
                hasObject = true;
            }
        }
    }

    public override void StartDialogue()
    {
        dialogueBox.SetActive(true);
        characterPortrait.SetActive(true);
        background.SetActive(true);

        index = 0;

        if (hasObject)
        {
            StartCoroutine(TypeObjectLine());
        }
        else
        {
            StartCoroutine(TypeLine());
        }
            dialogueStarted = true;
    }

    IEnumerator TypeObjectLine()
    {
        foreach (char c in objectLines[index].ToCharArray())
        {
            bodyText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public override void OnClick()
    {
        if (hasObject)
        {
            if (bodyText.text == objectLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                bodyText.text = objectLines[index];
            }
        }
        else
        {
            if (bodyText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                bodyText.text = lines[index];
            }
        }
    }
    public override void NextLine()
    {
        if (hasObject)
        {
            if (index < objectLines.Length - 1)
            {
                index++;
                bodyText.text = string.Empty;
                StartCoroutine(TypeObjectLine());
            }
            else
            {
                endDialogueEvent?.Invoke();
                ExitDialogue();
            }
        }
        else
        {
            if (index < lines.Length - 1)
            {
                index++;
                bodyText.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                ExitDialogue();
            }
        }
    }
}
