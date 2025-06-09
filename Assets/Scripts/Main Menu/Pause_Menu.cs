using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject pauseObject;

    private void Awake()
    {
        pauseObject.SetActive(false);
    }

    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void UnPause()
    {
        pauseObject.SetActive(false);
    }
}
