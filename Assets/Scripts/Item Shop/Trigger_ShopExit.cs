using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_ShopExit : MonoBehaviour
{
    public Shop_Manager manager;

    public Transform enterLocation;

    private Trigger_Interact trigger;
    [SerializeField] private string sceneName;

    private float doorTimer;
    public float doorCooldown = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponentInChildren<Trigger_Interact>();
        trigger.triggerEvent.AddListener(EnterBuilding);

        sceneName = PlayerPrefs.GetString("CurrentDay");
    }

    private void Awake()
    {
        doorTimer = doorCooldown;
    }
    private void Update()
    {
        if (doorTimer >= 0f)
        {
            doorTimer -= Time.deltaTime;
        }
    }

    private void EnterBuilding()
    {
        if (doorTimer < 0f)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            PlayerPrefs.SetInt("PlayerScore", manager.playerCash);
        }
    }
}
