using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mailbox : MonoBehaviour
{
    [Header("Mail delivered")]
    public bool mailDelivered;

    [Header("Address Index")]
    [SerializeField] private int addressNumber;

    public GameObject upFlag;
    public GameObject downFlag;

    private Level_Manager manager;
    private Minigame_Data data;
    public Trigger_Interact trigger;

    public List<int> letters = new List<int>(); 
    public UnityEvent deliverEvent = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mailDelivered = false;
        trigger = GetComponentInChildren<Trigger_Interact>();
        data = FindAnyObjectByType<Minigame_Data>();
        trigger.triggerEvent.AddListener(DeliverMail);

        upFlag.SetActive(true);
        downFlag.SetActive(false);
    }

    private void DeliverMail()
    {
        if (!mailDelivered)
        {
            for (int i = 0; i < data.addresses.Count; i++)
            {
                if ((addressNumber) - 1 == i)
                {
                    for (int j = 0; j < data.addresses[i].Count; j++)
                    {
                        letters.Add(j);
                        deliverEvent?.Invoke();
                    }
                    mailDelivered = true;
                }
            }

            upFlag.SetActive(false);
            downFlag.SetActive(true);
        }
    }
}
