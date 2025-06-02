using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public Transform player;
    public Vector3 exitPosition;
    public List<Mailbox> mailboxes = new List<Mailbox>();

    public int lettersDelivered;
    public bool allLettersDelivered;

    public Minigame_Data data;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        data = FindAnyObjectByType<Minigame_Data>();
        CharacterController controller = player.GetComponent<CharacterController>();
        controller.enabled = false;
        allLettersDelivered = false;

        float xPos = PlayerPrefs.GetFloat("X");
        float yPos = PlayerPrefs.GetFloat("Y");
        float zPos = PlayerPrefs.GetFloat("Z");
        exitPosition = new Vector3(xPos, yPos, zPos);

        player.position = exitPosition;
        controller.enabled = true;

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

            foreach(List<int> address in data.addresses)
            {
                address.Clear();
            }
        }
    }
}