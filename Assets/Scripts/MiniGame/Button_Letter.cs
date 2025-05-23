using UnityEngine;
using UnityEngine.Events;

public class Button_Letter : MonoBehaviour
{
    public UnityEvent grabLetterEvent = new UnityEvent();

    public void OnClick()
    {
        grabLetterEvent?.Invoke();
    }
}
