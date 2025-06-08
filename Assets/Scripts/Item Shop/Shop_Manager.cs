using TMPro;
using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    public Player_Interact interact;
    public TextMeshProUGUI moneyText;

    public int playerCash;
    public bool canShop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerCash = PlayerPrefs.GetInt("PlayerScore");
        moneyText.text = playerCash.ToString();
        canShop = false;
    }

    public void BuyItem()
    {
        moneyText.text = playerCash.ToString();
    }
}
