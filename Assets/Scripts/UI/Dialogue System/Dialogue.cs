using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    //references
    public GameObject dialogueBox;
    public GameObject characterPortrait;
    public GameObject background;
    public Player_Inventory playerInventory;
    public End_Condition endCondition;

    //ui elements
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI titleText;

    //character name
    public string charName;
    //lines in dialogue object
    public string[] lines;
    //character portraits
    public Sprite charSprite;
    //character portrait destination
    public Image charPortrait;
    //condition for giving item through dialogue
    public string itemGive;

    public bool itemGave;

    //data
    public float textSpeed;
    public int index;
    public bool dialogueStarted;

    public UnityEvent endDialogueEvent = new UnityEvent();

    private void Awake()
    {
        endCondition = FindAnyObjectByType<End_Condition>();

        dialogueBox.SetActive(false);
        titleText.text = charName;
        bodyText.text = string.Empty;

        charPortrait.sprite = charSprite;
        characterPortrait.SetActive(false);
        background.SetActive(false);
        dialogueStarted = false;
        itemGave = false;
    }

    public virtual void StartDialogue()
    {
        dialogueBox.SetActive(true);
        characterPortrait.SetActive(true);
        background.SetActive(true);

        index = 0;
        StartCoroutine(TypeLine());
        dialogueStarted = true; 
    }

    public virtual void ExitDialogue()
    {
        dialogueBox.SetActive(false);
        characterPortrait.SetActive(false);
        background.SetActive(false);
        bodyText.text = string.Empty;
        index = 0;

        if (itemGive != null && !itemGave)
        {
            playerInventory = FindAnyObjectByType<Player_Inventory>();
            playerInventory.inventory.Add(itemGive);
            itemGave = true;
        }
        dialogueStarted = false;
    }

    public IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            bodyText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public virtual void OnClick()
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

    public virtual void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            bodyText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            endDialogueEvent?.Invoke();
            ExitDialogue();
        }
    }

    //I may revisit this this one day
/*    void SwapPortrait()
    {
        int key = lines[index].IndexOf("]");
        string result = lines[index].Substring(1, key);

        for (int i = 0; i < charSprites.Count; i++)
        {
            string val = i.ToString();

            if (val == result)
            {
                charPortrait.sprite = charSprites[i];
            }
        }

        text = lines[index].Substring(lines[index].IndexOf("]") + 1);
    }*/
}