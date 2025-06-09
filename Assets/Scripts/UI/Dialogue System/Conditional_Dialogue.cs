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

        endCondition = FindAnyObjectByType<End_Condition>();

        dialogueBox.SetActive(false);
        titleText.text = charName;
        bodyText.text = string.Empty;

        charPortrait.sprite = charSprite;
        characterPortrait.SetActive(false);
        background.SetActive(false);
        dialogueStarted = false;
    }

    public override void StartDialogue()
    {
        dialogueBox.SetActive(true);
        characterPortrait.SetActive(true);
        background.SetActive(true);

        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            if (inventory.inventory[i] == neededObject)
            {
                hasObject = true;
            }
        }

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

    public override void ExitDialogue()
    {
        dialogueBox.SetActive(false);
        characterPortrait.SetActive(false);
        background.SetActive(false);
        bodyText.text = string.Empty;
        index = 0;

        if (itemGive != null && !itemGave && hasObject)
        {
            playerInventory = FindAnyObjectByType<Player_Inventory>();
            playerInventory.inventory.Add(itemGive);
            itemGave = true;
        }
        dialogueStarted = false;
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
