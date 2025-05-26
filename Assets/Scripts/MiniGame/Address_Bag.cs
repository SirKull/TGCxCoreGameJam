using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Address_Bag : MonoBehaviour
{
    //references
    private Minigame_Manager manager;
    public Minigame_Data data;
    private Letter heldLetter;

    private bool canClick;
    public int addressValue;

    void Start()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Letter")
        {
            heldLetter = collision.GetComponent<Letter>();
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
            heldLetter.SetDownLetter();

            for(int i = 0; i < data.addresses.Count; i++)
            {
                if((addressValue - 1) == i)
                {
                    data.addresses[i].Add(heldLetter.addressValue);
                }
            }
        }
    }
}
