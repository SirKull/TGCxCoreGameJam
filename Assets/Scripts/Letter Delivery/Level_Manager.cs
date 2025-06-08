using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    //UI
    public GameObject scoreObject;
    public TextMeshProUGUI lettersText;
    public TextMeshProUGUI payText;
    public TextMeshProUGUI moneyUI;

    //Scene references
    public Transform player;
    public Vector3 exitPosition;
    public List<Mailbox> mailboxes = new List<Mailbox>();
    public Trigger_Exit exit;

    public int lettersDelivered;
    public bool allLettersDelivered;

    public Minigame_Data data;

    [Header("Scoring")]
    public int correctMailMoney;
    public int adCommissionMoney;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        data = FindAnyObjectByType<Minigame_Data>();
        CharacterController controller = player.GetComponent<CharacterController>();
        controller.enabled = false;
        allLettersDelivered = false;

        scoreObject.SetActive(false);
        moneyUI.text = PlayerPrefs.GetInt("PlayerScore").ToString();

        float xPos = PlayerPrefs.GetFloat("X");
        float yPos = PlayerPrefs.GetFloat("Y");
        float zPos = PlayerPrefs.GetFloat("Z");
        exitPosition = new Vector3(xPos, yPos, zPos);

        player.position = exitPosition;
        controller.enabled = true;

        exit.interactEvent.AddListener(ExitScene);

        foreach (Mailbox mailbox in mailboxes)
        {
            mailbox.deliverEvent.AddListener(CheckMailDelivered);
        }
    }

    void CheckMailDelivered()
    {
        lettersDelivered++;
        if(lettersDelivered == data.lettersToDeliver)
        {
            allLettersDelivered = true;

            CheckScore();
        }
    }

    void CheckScore()
    {
        scoreObject.SetActive(true);

        int lettersCorrect = 0;
        for(int i = 0; i < data.addresses.Count; i++)
        {
            foreach (int addressVal in data.addresses[i])
            {
                if (addressVal == i + 1)
                {
                    int score = PlayerPrefs.GetInt("PlayerScore");
                    score += correctMailMoney;
                    PlayerPrefs.SetInt("PlayerScore", score);
                    payText.text = score.ToString();
                    lettersCorrect++;
                }
                else
                {
                    Debug.Log("no score");
                }
            }
            lettersText.text = lettersCorrect.ToString();
        }
    }

    void ExitScene()
    {
        if(allLettersDelivered)
        {

        }
    }
}