using UnityEngine;
using UnityEngine.Events;

public class Tutorial_Letters : Button_Letter
{
    public bool firstTutorial = true;

    public UnityEvent tutorialEvent = new UnityEvent();

    public override void OnClick()
    {
        grabLetterEvent?.Invoke();
        if (firstTutorial)
        {
            tutorialEvent?.Invoke();
        }
        firstTutorial = false;
    }
}
