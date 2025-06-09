using UnityEditor.Rendering;
using UnityEngine;

public class Reward_Manager : MonoBehaviour
{
    public Player_Inventory inventory;

    public GameObject snowGlobe;
    public GameObject plant;
    public GameObject keyboard;
    public GameObject beaver;
    public GameObject castle;
    public GameObject licensePlate;

    void Awake()
    {
        inventory = FindAnyObjectByType<Player_Inventory>();

        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            if (inventory.inventory[i] == "snowglobe")
            {
                snowGlobe.SetActive(true);
            }
            if (inventory.inventory[i] == "plant")
            {
                plant.SetActive(true);
            }
            if (inventory.inventory[i] == "keyboard")
            {
                keyboard.SetActive(true);
            }
            if (inventory.inventory[i] == "beaver")
            {
                beaver.SetActive(true);
            }
            if (inventory.inventory[i] == "castle")
            {
                castle.SetActive(true);
            }
            if (inventory.inventory[i] == "licenseplate")
            {
                licensePlate.SetActive(true);
            }
        }
    }
}
