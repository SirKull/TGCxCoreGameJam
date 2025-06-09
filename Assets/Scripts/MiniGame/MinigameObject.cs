using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinigameObject : MonoBehaviour
{
    public Camera mainCam;
    public Table table;
    public Minigame_Manager manager;

    public GameObject imageObject;
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
            Image image = GetComponentInChildren<Image>();
            image.raycastTarget = false;
        }
    }
    public virtual void OnClick()
    {
        if (!manager.objectHeld)
        {
            objectHeld = true;
            manager.objectHeld = true;
            manager.heldLetterIndex = objectID;
            imageObject.SetActive(true);

            if (objectInBag)
            {
                objectExitEvent?.Invoke();
                objectInBag = false;
            }
        }
    }

    public void SetDown()
    {
        if (!objectInBag)
        {
            objectHeld = false;
            Image image = GetComponentInChildren<Image>();
            image.raycastTarget = true;
        }
    }

    public void TurnOffObject()
    {
        imageObject.SetActive(false);
    }
}
