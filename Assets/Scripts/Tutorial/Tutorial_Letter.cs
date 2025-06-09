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
            imageObject.SetActive(true);

            if (objectInBag)
            {
                objectExitEvent?.Invoke();
                objectInBag = false;
            }
        }
    }
}
