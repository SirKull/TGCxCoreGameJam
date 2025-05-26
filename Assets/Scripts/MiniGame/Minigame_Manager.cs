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

    //store held letter values;
    public int heldLetterIndex;

    //list of lists
    public List<List<SO_Letter>> letterDays = new List<List<SO_Letter>>();

    //lists of each day's letters
    //must be configured in inspector
    public List<SO_Letter> day1Letters = new List<SO_Letter>();
    public List<SO_Letter> day2Letters = new List<SO_Letter>();
    public List<SO_Letter> day3Letters = new List<SO_Letter>();
    public List<SO_Letter> day4Letters = new List<SO_Letter>();
    public List<SO_Letter> day5Letters = new List<SO_Letter>();

    //current day letter list
    public List<SO_Letter> letterList;

    //letter to get
    public SO_Letter letterGrabbed;

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
    }

    private void SetWeekdays(int _day)
    {
        letterList = new List<SO_Letter>();

        //5 is number of days
        for(int i = 0; i < 5; i++)
        {
            //have to subtract 1 from _day
            //lists store first position as "0"
            if(i == (_day - 1))
            {
                foreach (SO_Letter letter in letterDays[i])
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
                letterGrabbed = letterList[i];

                heldLetterIndex = letterGrabbed.letterIndex;
                letterList.Remove(letterGrabbed);
            }
            letterHeld = true;
        }
    }

    public void ResetLetter()
    {
        letterHeld = false;
        heldLetterIndex = 0;
    }
}
