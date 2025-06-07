using UnityEngine;

public class Tutorial_Letter : MinigameObject
{
    public Tutorial_Manager tutorialManager;

    public override void OnClick()
    {
        if (!tutorialManager.objectHeld)
        {
            objectHeld = true;
            tutorialManager.objectHeld = true;
            tutorialManager.heldLetterIndex = objectID;

            if (objectInBag)
            {
                objectExitEvent?.Invoke();
                objectInBag = false;
            }
        }
    }
}
