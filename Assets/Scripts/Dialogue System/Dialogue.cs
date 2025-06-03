using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    
    public TextMeshProUGUI textComponent;

    //lines in dialogue object
    public string[] lines;
    //character portraits
    public Sprite charSprite;
    //character portrait destination
    public Image charPortrait;

    public float textSpeed;

    private int index;

    private void Start()
    {
        dialogueBox.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
        charPortrait.sprite = charSprite;
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void OnClick()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
            SwapPortrait();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //I may revisit this this one day
    void SwapPortrait()
    {
/*        int key = lines[index].IndexOf("]");
        string result = lines[index].Substring(1, key);

        for (int i = 0; i < charSprites.Count; i++)
        {
            string val = i.ToString();

            if (val == result)
            {
                charPortrait.sprite = charSprites[i];
            }
        }

        text = lines[index].Substring(lines[index].IndexOf("]") + 1);*/
    }
}