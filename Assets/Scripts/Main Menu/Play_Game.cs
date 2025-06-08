using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_Game : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Initialize");
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}