using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Address_Bag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Minigame_Manager manager;

    private bool canClick;

    public int addressValue;

    void Start()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canClick = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canClick = false;
    }

    public void OnClick()
    {
        if (canClick)
        {
           Letter heldLetter = FindAnyObjectByType<Letter>();
           heldLetter.SetDownLetter();
           if(heldLetter.addressValue != addressValue)
            {
                manager.lettersCorrect = false;
            }
        }
    }
}
