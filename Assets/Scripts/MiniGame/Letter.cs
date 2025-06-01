using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Camera mainCam;
    public Table table;
    public Minigame_Manager manager;

    //letter ID
    public int letterID;

    //address (destination) ID
    public int addressValue;

    //check if letter is being held
    public bool letterHeld;
    //check if letter is in address bag
    public bool letterInBag;

    public Vector2 mousePosition;

    public UnityEvent bagExitEvent = new UnityEvent();

    public void Awake()
    {
        mainCam = Camera.main;
        table = FindAnyObjectByType<Table>();
        table.setDownEvent.AddListener(SetDownLetter);
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    public void OnClick()
    {
        if (!manager.letterHeld)
        {
            letterHeld = true;
            manager.letterHeld = true;
            manager.heldLetterIndex = letterID;

            if (letterInBag)
            {
                bagExitEvent?.Invoke();
                letterInBag = false;
            }
        }
    }


    private void Update()
    {
        if (letterHeld)
        {
            mousePosition = Mouse.current.position.ReadValue();
            this.GetComponent<RectTransform>().position = new Vector2(mousePosition.x, mousePosition.y);
            Image image = GetComponent<Image>();
            image.raycastTarget = false;
        }
    }

    public void SetDownLetter()
    {
        letterHeld = false;
        Image image = GetComponent<Image>();
        image.raycastTarget = true;
    }
}
