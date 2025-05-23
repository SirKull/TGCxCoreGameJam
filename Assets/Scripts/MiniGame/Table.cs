using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Table : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Minigame_Manager manager;

    public GameObject letterExample;

    public static Dictionary<int, GameObject> letterSprites = new Dictionary<int, GameObject>();

    public bool canClick;

    public UnityEvent setDownEvent = new UnityEvent();

    public void Awake()
    {
        manager = FindAnyObjectByType<Minigame_Manager>();

        letterSprites.Add(1, letterExample);
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
            if (manager.letterHeld)
            {
                int id = manager.heldLetterIndex;
                letterSprites[id].SetActive(true);
                manager.ResetLetter();
                canClick = false;
            }
            else
            {
                setDownEvent?.Invoke();
            }
        }
    }
}
