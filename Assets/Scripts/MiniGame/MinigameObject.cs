using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinigameObject : MonoBehaviour
{
    public Camera mainCam;
    public Table table;
    public Minigame_Manager manager;

    //address ID
    [Header("AD object ID is always 0")]
    public int objectID;
    //address (destination) ID
    [Header("AD destination ID is for commission")]
    public int addressValue;

    //check if ad is being held
    public bool objectHeld;
    //check if ad is in address bag
    public bool objectInBag;

    public Vector2 mousePosition;
    public UnityEvent objectExitEvent = new UnityEvent();

    public void Awake()
    {
        mainCam = Camera.main;
        table = FindAnyObjectByType<Table>();
        table.setDownEvent.AddListener(SetDown);
        manager = FindAnyObjectByType<Minigame_Manager>();
    }

    private void Update()
    {
        if (objectHeld)
        {
            mousePosition = Mouse.current.position.ReadValue();
            this.GetComponent<RectTransform>().position = new Vector2(mousePosition.x, mousePosition.y);
            Image image = GetComponent<Image>();
            image.raycastTarget = false;
        }
    }
    public void OnClick()
    {
        if (!manager.objectHeld)
        {
            objectHeld = true;
            manager.objectHeld = true;
            manager.heldLetterIndex = objectID;

            if (objectInBag)
            {
                objectExitEvent?.Invoke();
                objectInBag = false;
            }
        }
    }

    public void SetDown()
    {
        objectHeld = false;
        Image image = GetComponent<Image>();
        image.raycastTarget = true;
    }
}
