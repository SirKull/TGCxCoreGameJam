using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public Minigame_Manager manager;
    public void OnClick()
    {
        if (manager.allLettersPlaced)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
