using TMPro;
using UnityEngine;

public class Sand_Dollar : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public int value = 1;
    public GameObject sandDollar;
    private bool collected;

    private void Awake()
    {
        collected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            int money = PlayerPrefs.GetInt("PlayerScore");
            money += value;
            PlayerPrefs.SetInt("PlayerScore", money);
            collected = true;
            moneyText.text = money.ToString();
            sandDollar.SetActive(false);
        }
    }
}
