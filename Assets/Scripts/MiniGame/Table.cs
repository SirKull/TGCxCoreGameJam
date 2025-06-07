using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Table : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Minigame_Manager manager;

    public bool canClick;

    public UnityEvent setDownEvent = new UnityEvent();

    public void Awake()
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

    public virtual void OnClick()
    {
        if (canClick && manager.objectHeld)
        {
            setDownEvent?.Invoke();
            manager.ResetLetter();
        }
    }
}
