using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Camera mainCam;
    public Table table;

    public int addressValue;

    public bool letterHeld;

    public Vector2 mousePosition;

    public void Awake()
    {
        mainCam = Camera.main;
        table = FindAnyObjectByType<Table>();
        table.setDownEvent.AddListener(SetDownLetter);
    }

    public void OnClick()
    {
        letterHeld = true;
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
