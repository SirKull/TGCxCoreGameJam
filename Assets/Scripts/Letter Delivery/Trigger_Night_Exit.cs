using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Trigger_Night_Exit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
        }
    }

    public void Interact()
    {
        if (triggered)
        {
            int day = PlayerPrefs.GetInt("Day");
            day++;
            PlayerPrefs.SetInt("Day", day);
            SceneManager.LoadScene(sceneName);
        }
    }
}
