using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Manager : MonoBehaviour
{
    public Dialogue dialogue;
    public Player_Move playerMove;
    public Fade fade;

    [SerializeField] private float introDelay = 2f;
    [SerializeField] private string nextSceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fade.FadeImage(true));
        StartCoroutine(IntroText());
        playerMove.canMove = false;
        dialogue.endDialogueEvent.AddListener(StartTutorial);
    }

    IEnumerator IntroText()
    {
        yield return new WaitForSeconds(introDelay);
        dialogue.StartDialogue();
    }

    public void StartTutorial()
    {
        StartCoroutine(fade.FadeImage(false));
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(introDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
