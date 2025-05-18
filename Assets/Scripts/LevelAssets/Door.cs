using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [Header("Enter/Exit Door")]
    public bool enterDoor;

    private Level_Manager manager;
    public Transform enterLocation;

    private Trigger_Interact trigger;
    [SerializeField] private string sceneName;

    private float doorTimer;
    public float doorCooldown = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponentInChildren<Trigger_Interact>();
        manager = FindAnyObjectByType<Level_Manager>();
        trigger.triggerEvent.AddListener(EnterBuilding);
    }

    private void Awake()
    {
        doorTimer = doorCooldown;
    }

    private void Update()
    {
        if(doorTimer >= 0f)
        {
            doorTimer -= Time.deltaTime;
        }
    }

    private void EnterBuilding()
    {
        if(doorTimer < 0f)
        {
            if (enterDoor)
            {
                PlayerPrefs.SetFloat("X", enterLocation.position.x); PlayerPrefs.SetFloat("Y", enterLocation.position.y); PlayerPrefs.SetFloat("Z", enterLocation.position.z);
            }

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
