using UnityEngine;
using UnityEngine.Events;

public class Tutorial_AddressBook : AddressBook
{
    public bool firstTutorialBook = true;
    public bool firstTutorialImage = true;

    public UnityEvent tutorialEvent = new UnityEvent();

    public override void OnClick()
    {
        addressImage.SetActive(true);
        if (firstTutorialBook)
        {
            tutorialEvent?.Invoke();
            firstTutorialBook = false;
        }
    }

    public override void OnImageClick()
    {
        addressImage.SetActive(false);
        if (firstTutorialImage)
        {
            tutorialEvent?.Invoke();
            firstTutorialImage = false;
        }
    }
}
