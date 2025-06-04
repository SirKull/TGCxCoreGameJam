using UnityEngine;

public class AddressBook : MonoBehaviour
{
    public GameObject addressImage;

    private void Start()
    {
        addressImage.SetActive(false);
    }

    public virtual void OnClick()
    {
        addressImage.SetActive(true);
    }

    public virtual void OnImageClick()
    {
        addressImage.SetActive(false);
    }
}
