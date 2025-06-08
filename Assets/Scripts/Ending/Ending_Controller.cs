using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Controller : MonoBehaviour
{
    public End_Condition endCondition;
    public Fade fade;

    public GameObject gpGenerous;
    public GameObject gpNonGenerous;
    public GameObject parentGenerous;
    public GameObject parentNonGenerous;
    public GameObject harperGenerous;
    public GameObject harperNonGenerous;
    public GameObject gariGenerous;
    public GameObject gariNonGenerous;

    void Awake()
    {
        StartCoroutine(fade.FadeImage(true)); 

        endCondition = FindAnyObjectByType<End_Condition>();

        SetCards();
    }


    void SetCards()
    {
        if(endCondition.grandparentGenerous >= 3)
        {
            gpGenerous.SetActive(true);
            gpNonGenerous.SetActive(false);
        }
        else
        {
            gpNonGenerous.SetActive(true);
            gpGenerous.SetActive(false);
        }

        if(endCondition.parentGenerous >= 3)
        {
            parentGenerous.SetActive(true);
            parentNonGenerous.SetActive(false);
        }
        else
        {
            parentGenerous.SetActive(false);
            parentNonGenerous.SetActive(true);
        }

        if(endCondition.harperGenerous >= 3)
        {
            harperGenerous.SetActive(true);
            harperNonGenerous.SetActive(false);
        }
        else
        {
            harperGenerous.SetActive(false);
            harperNonGenerous.SetActive(true);
        }

        if(endCondition.gariGenerous >= 3)
        {
            gariGenerous.SetActive(true);
            gariNonGenerous.SetActive(false);
        }
        else
        {
            gariGenerous.SetActive(false);
            gariNonGenerous.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
