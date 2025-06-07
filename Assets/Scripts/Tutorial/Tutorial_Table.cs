using UnityEngine;
using UnityEngine.Events;

public class Tutorial_Table : Table
{
    public Tutorial_Manager tutorialManager;
    
    public bool firstTutorial = true;

    public UnityEvent tutorialEvent = new UnityEvent();

    public override void OnClick()
    {
        if (canClick && tutorialManager.objectHeld)
        {
            setDownEvent?.Invoke();
            tutorialManager.ResetLetter();

            if (firstTutorial)
            {
                tutorialEvent.Invoke();
                firstTutorial = false;
            }
        }
    }
}
