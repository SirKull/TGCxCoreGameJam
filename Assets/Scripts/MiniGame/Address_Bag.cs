using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Address_Bag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> letter3dObjects = new List<GameObject>();

    public List<GameObject> letter2dObjects = new List<GameObject>();

    //references
    private Minigame_Manager manager;
    public Minigame_Data data;
    public MinigameObject heldObject;

    public bool canClick;
    public bool selected;
    public bool hasObject;
    public int addressValue;

    void Start()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();

        for (int i = 0; i < letter3dObjects.Count; i++)
        {
            letter3dObjects[i].SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Letter")
        {
            heldObject = collision.GetComponent<MinigameObject>();
            canClick = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Letter")
        {
            canClick = false;
        }
    }

    public virtual void OnClick()
    {
        if (canClick && selected)
        {
            heldObject.SetDown();
            manager.ResetLetter();
            heldObject.objectInBag = true;

            letter2dObjects.Add(heldObject.gameObject);

            for(int i = 0; i < data.addresses.Count; i++)
            {
                if((addressValue - 1) == i)
                {
                    data.addresses[i].Add(heldObject.objectID);
                    letter3dObjects[i].gameObject.SetActive(true);

                    heldObject.TurnOffObject();
                    hasObject = true;
                }
            }

            canClick = false;
            //add 1 letter
            manager.CheckLettersPlaced(1);
        }
        else if (heldObject)
        {
            RemoveLetter();
        }
    }

    public virtual void RemoveLetter()
    {
        int letterID = manager.heldLetterIndex;

        for(int i = 0; i < data.addresses.Count; i++)
        {
            if ((addressValue - 1) == i)
            {
                data.addresses[i].RemoveAll(item => item == letterID);
            }
        }
        for(int i = 0; i <= letter2dObjects.Count; i++)
        {
            if(i == (letter2dObjects.Count - 1))
            {
                letter3dObjects[i].gameObject.SetActive(false);
                MinigameObject targetObject = letter2dObjects[i].GetComponent<MinigameObject>();
                targetObject.OnClick();
                letter2dObjects.Remove(targetObject.gameObject);
            }
        }
        //subtract 1 letter
        manager.CheckLettersPlaced(-1);
    }
}
