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

        //day = PlayerPrefs.GetInt("Day");
        day = 1;

        SetWeekdays(day);
    }

    private void SetWeekdays(int _day)
    {
        letterList = new List<SO_Letter>();

        //this is dumb
        if (_day == 1)
        {
            foreach(SO_Letter letter in day1Letters)
            {
                letterList.Add(letter);
            }
        }
        if(_day == 2)
        {
            foreach (SO_Letter letter in day2Letters)
            {
                letterList.Add(letter);
            }
        }
        if (_day == 3)
        {
            foreach (SO_Letter letter in day3Letters)
            {
                letterList.Add(letter);
            }
        }
        if (_day == 4)
        {
            foreach (SO_Letter letter in day4Letters)
            {
                letterList.Add(letter);
            }
        }
        if (_day == 5)
        {
            foreach (SO_Letter letter in day5Letters)
            {
                letterList.Add(letter);
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
