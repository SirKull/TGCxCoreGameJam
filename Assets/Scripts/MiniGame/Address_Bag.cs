using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Address_Bag : MonoBehaviour
{
    private Minigame_Manager manager;

    public bool canClick;

    public int addressValue;

    void Start()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Letter")
        {
            canClick = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Letter")
        {
            canClick = false;
        }
    }

    public void OnClick()
    {
        if (canClick)
        {
           Letter heldLetter = FindAnyObjectByType<Letter>();
           heldLetter.SetDownLetter();

/*           for(int i = 0; i < addressValue; i++)
            {
                if(heldLetter.addressValue == addressValue)
                {

                }
            }*/
        }
    }
}
