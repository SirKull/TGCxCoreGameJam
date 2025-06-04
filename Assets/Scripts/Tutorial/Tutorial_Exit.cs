using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Exit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public Tutorial_Manager manager;
    public void OnClick()
    {
        if (manager.allLettersPlaced)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
