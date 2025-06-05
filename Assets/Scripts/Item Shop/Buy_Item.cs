using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buy_Item : MonoBehaviour
{
    public Player_Inventory inventory;
    public Shop_Manager manager;

    public GameObject moneyMessage;
    public float messageTime = 2.5f;

    public bool canBuy;

    public string itemName;
    [SerializeField] int price;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canBuy = true;
        inventory = FindAnyObjectByType<Player_Inventory>();
        manager = FindAnyObjectByType<Shop_Manager>();
    }

    public void OnClick()
    {
        if (manager.canShop && canBuy)
        {
            if (manager.playerCash >= price)
            {
                manager.playerCash -= price;
                manager.BuyItem();
                inventory.inventory.Add(itemName);
                canBuy = false;
            }
            else
            {
                moneyMessage.SetActive(true);
                StartCoroutine(MessageTimer());
            }
        }
    }

    public IEnumerator MessageTimer()
    {
        yield return new WaitForSeconds(messageTime);
        moneyMessage.SetActive(false);
    }
}
