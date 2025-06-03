using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI titleText;

    //character name
    [SerializeField] private string charName;
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
        titleText.text = charName;
        bodyText.text = string.Empty;

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
            bodyText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void OnClick()
    {
        if (bodyText.text == lines[index])
        {
            NextLine();
            SwapPortrait();
        }
        else
        {
            StopAllCoroutines();
            bodyText.text = lines[index];
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            bodyText.text = string.Empty;
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