using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Address_Bag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //references
    private Minigame_Manager manager;
    public Minigame_Data data;
    private MinigameObject heldObject;

    public bool canClick;
    public bool selected;
    public int addressValue;

    void Start()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Letter")
        {
            heldObject = collision.GetComponent<MinigameObject>();
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
        if (canClick && selected)
        {
            heldObject.SetDown();
            manager.ResetLetter();
            heldObject.objectInBag = true;
            heldObject.objectExitEvent.AddListener(RemoveLetter);

            for(int i = 0; i < data.addresses.Count; i++)
            {
                if((addressValue - 1) == i)
                {
                    data.addresses[i].Add(heldObject.addressValue);
                }
            }
            canClick = false;
            //add 1 letter
            manager.CheckLettersPlaced(1);
        }
    }

    private void RemoveLetter()
    {
        int letterID = manager.heldLetterIndex;

        for(int i = 0; i < data.addresses.Count; i++)
        {
            //is not removing certain values
            if ((addressValue - 1) == i)
            {
                data.addresses[i].RemoveAll(item => item == letterID);
            }
        }
        heldObject.objectExitEvent.RemoveAllListeners();
        //subtract 1 letter
        manager.CheckLettersPlaced(-1);
    }
}
