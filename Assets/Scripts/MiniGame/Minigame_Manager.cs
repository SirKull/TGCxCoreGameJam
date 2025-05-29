using System;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Manager : MonoBehaviour
{
    public Button_Letter buttonLetter;

    public int day;

    public bool lettersCorrect;
    public bool allLettersPlaced;
    public bool letterHeld;

    //store total letters for day
    public int totalLetters;

    //number of letters placed
    public int lettersPlaced;

    //store held letter values;
    public int heldLetterIndex;

    //list of lists
    public List<List<GameObject>> letterDays = new List<List<GameObject>>();

    //lists of each day's letters
    //must be configured in inspector
    public List<GameObject> day1Letters = new List<GameObject>();
    public List<GameObject> day2Letters = new List<GameObject>();
    public List<GameObject> day3Letters = new List<GameObject>();
    public List<GameObject> day4Letters = new List<GameObject>();
    public List<GameObject> day5Letters = new List<GameObject>();

    //current day letter list
    public List<GameObject> letterList;

    //letter to get
    public GameObject letterGrabbed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        buttonLetter.grabLetterEvent.AddListener(GetLetter);

        letterDays.Add(day1Letters);
        letterDays.Add(day2Letters);
        letterDays.Add(day3Letters);
        letterDays.Add(day4Letters);
        letterDays.Add(day5Letters);

        //day = PlayerPrefs.GetInt("Day");
        day = 1;

        SetWeekdays(day);
        totalLetters = letterList.Count;
    }

    private void SetWeekdays(int _day)
    {
        letterList = new List<GameObject>();

        //5 is number of days
        for(int i = 0; i < 5; i++)
        {
            //have to subtract 1 from _day
            //lists store first position as "0"
            if(i == (_day - 1))
            {
                foreach (GameObject letter in letterDays[i])
                {
                    letterList.Add(letter);
                }
            }
        }
    }

    public void GetLetter()
    {
        if (!letterHeld)
        {
            for (int i = 0; i < letterList.Count; i++)
            {
                if(i + 1 == letterList.Count)
                {
                    letterGrabbed = letterList[i];
                    letterList[i].SetActive(true);
                    Letter letterData = letterGrabbed.GetComponent<Letter>();

                    letterData.letterHeld = true;
                    letterList.Remove(letterGrabbed);

                    heldLetterIndex = letterData.letterID;

                    letterHeld = true;
                }
            }
        }
    }

    public void ResetLetter()
    {
        letterHeld = false;
        heldLetterIndex = 0;
    }

    public void CheckLettersPlaced(int letter)
    {
        lettersPlaced += letter;

        if(lettersPlaced == totalLetters)
        {
            allLettersPlaced = true;
        }
        else
        {
            allLettersPlaced = false;
        }
    }
}
