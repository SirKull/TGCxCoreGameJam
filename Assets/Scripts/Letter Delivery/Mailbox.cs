using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    [Header("Mail delivered")]
    public bool mailDelivered;

    [Header("Address Index")]
    [SerializeField] private int addressNumber;

    private Level_Manager manager;
    private Minigame_Data data;
    public Trigger_Interact trigger;

    public List<int> letters = new List<int>(); 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mailDelivered = false;
        trigger = GetComponentInChildren<Trigger_Interact>();
        data = FindAnyObjectByType<Minigame_Data>();
        trigger.triggerEvent.AddListener(DeliverMail);
    }

    private void DeliverMail()
    {
        if (!mailDelivered)
        {
            for (int i = 0; i < data.addresses.Count; i++)
            {
                if ((addressNumber) - 1 == i)
                {
                    foreach (int j in data.addresses[i])
                    {
                        letters.Add(j);
                    }
                    mailDelivered = true;
                }
            }
        }
    }
}
