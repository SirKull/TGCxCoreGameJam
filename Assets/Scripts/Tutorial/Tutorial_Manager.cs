using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    //UI references

    public Fade fade;
    //tutorial dialogue
    public GameObject dialogueBox;
    //textbox to print tutorial text to
    public TextMeshProUGUI tutorialText;
    //screensized button to advanced dialogue
    public GameObject button;
    //reference to example letter
    public GameObject exampleLetter;

    //unique tutorial elements
    public Tutorial_Letters tutorialLetter;
    public Tutorial_Table tutorialTable;
    public Tutorial_AddressBook tutorialAddressBook;
    public Tutorial_AddressBag tutorialAddressBag;

    public int tutorialID = 0;

    public static Dictionary<int, string> tutorialMessages = new Dictionary<int, string>()
    {
        [0] = "The most difficult part of this job is sorting the mail.",
        [1] = "The letters we receive don't always have the right address.",
        [2] = "Sometimes we have to do a little big of 'creative guessing' when sorting.",
        [3] = "Take a letter from the stack to see what I mean.",
        [4] = "Now put it on the table.",
        [5] = "Yup, see? The sender didn't quite get the address number right.",
        [6] = "Open up the address book to see all the addresses in Sealem.",
        [7] = "Ok, looks like the sender got the name right but was off with the house number.",
        [8] = "Go ahead and put that letter in the '5 Sealem Road' bag, since that's where that person lives.",
        [9] = "Once you've sorted all the letters, you can start with delivery.",
        [10] = "This is a temp gig, so you're only getting paid if you deliver the letters to the right houses.",
        [11] = "When you start delivering, you won't be able to make any changes to where the letters are going.",
        [12] = "Okay, looks like you're ready for the real thing!"
    };

    //carryover from main minigame manager
    public bool objectHeld;
    public int heldLetterIndex;
    public int lettersPlaced;
    public int totalLetters;
    public bool allLettersPlaced;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fade.FadeImage(true));

        dialogueBox.SetActive(true);
        WriteText(tutorialID);
        objectHeld = false;

        tutorialLetter.grabLetterEvent.AddListener(GetLetter);

        tutorialLetter.tutorialEvent.AddListener(IncrementID);
        tutorialTable.tutorialEvent.AddListener(IncrementID);
        tutorialAddressBook.tutorialEvent.AddListener(IncrementID);
        tutorialAddressBag.tutorialEvent.AddListener(IncrementID);

        //just one total letter for tutorial
        totalLetters = 1;
    }

    public void IncrementID()
    {
        Debug.Log("ButtonPressed");
        tutorialID++;
        WriteText(tutorialID);
        if(tutorialID == 3)
        {
            button.SetActive(false);
        }
        if(tutorialID == 5)
        {
            button.SetActive(true);
        }
        if(tutorialID == 6)
        {
            button.SetActive(false);
        }
        if(tutorialID == 7)
        {
            button.SetActive(false);
        }
        if (tutorialID == 9)
        {
            button.SetActive(true);
        }
        if (tutorialID == 12)
        {
            button.SetActive(false);
        }
    }

    public void WriteText(int id)
    {
        tutorialText.text = tutorialMessages[id].ToString();
    }

    public void GetLetter()
    {
        exampleLetter.SetActive(true);
        objectHeld = true;
        MinigameObject letter = exampleLetter.GetComponent<MinigameObject>();
        letter.objectHeld = true;
    }
    public void ResetLetter()
    {
        objectHeld = false;
        heldLetterIndex = 0;
    }
    public void CheckLettersPlaced(int letter)
    {
        lettersPlaced += letter;

        if (lettersPlaced == totalLetters)
        {
            allLettersPlaced = true;
        }
        else
        {
            allLettersPlaced = false;
        }
    }
}
