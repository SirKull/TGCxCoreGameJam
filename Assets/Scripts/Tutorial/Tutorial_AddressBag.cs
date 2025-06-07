using UnityEngine;
using UnityEngine.Events;

public class Tutorial_AddressBag : Address_Bag
{
    public Tutorial_Letter tutorialLetter;
    public Tutorial_Manager tutorialManager;

    public UnityEvent tutorialEvent = new UnityEvent();

    public override void OnClick()
    {
        if (canClick && selected)
        {
            tutorialLetter.SetDown();
            tutorialManager.ResetLetter();
            tutorialLetter.objectInBag = true;
            tutorialLetter.objectExitEvent.AddListener(RemoveLetter);

            canClick = false;

            tutorialEvent?.Invoke();
            //add 1 letter
            tutorialManager.CheckLettersPlaced(1);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Letter")
        {
            tutorialLetter = collision.GetComponent<Tutorial_Letter>();
            canClick = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Letter")
        {
            canClick = false;
        }
    }

    public override void RemoveLetter()
    {
        int letterID = tutorialManager.heldLetterIndex;

        //subtract 1 letter
        tutorialManager.CheckLettersPlaced(-1);
    }
}
