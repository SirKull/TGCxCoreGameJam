using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public Transform player;
    public Vector3 exitPosition;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CharacterController controller = player.GetComponent<CharacterController>();
        controller.enabled = false;

        float xPos = PlayerPrefs.GetFloat("X");
        float yPos = PlayerPrefs.GetFloat("Y");
        float zPos = PlayerPrefs.GetFloat("Z");
        exitPosition = new Vector3(xPos, yPos, zPos);

        Debug.Log(exitPosition);

        player.position = exitPosition;
        controller.enabled = true;
    }
}