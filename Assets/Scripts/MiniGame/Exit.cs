using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public Minigame_Manager manager;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Day") == 1)
        {
            sceneName = "Day_1_Delivery";
        }
        if (PlayerPrefs.GetInt("Day") == 2)
        {
            sceneName = "Day_2_Delivery";
        }
        if (PlayerPrefs.GetInt("Day") == 3)
        {
            sceneName = "Day_3_Delivery";
        }
        if (PlayerPrefs.GetInt("Day") == 4)
        {
            sceneName = "Day_4_Delivery";
        }
        if (PlayerPrefs.GetInt("Day") == 5)
        {
            sceneName = "Day_5_Delivery";
        }
    }
    public void OnClick()
    {
        if (manager.allLettersPlaced)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
