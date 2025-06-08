using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image image;
    
    public IEnumerator FadeImage(bool fadeAway)
    {
        image.gameObject.SetActive(true);
        if (fadeAway)
        {
            for(float i = 2; i >= 0; i-= Time.deltaTime)
            {
                image.color = new Color(0, 0, 0, i);
                yield return null;
            }
            image.gameObject.SetActive(false);
        }
        else
        {
            {
                for(float i = 0; i <= 2; i += Time.deltaTime)
                {
                    image.color = new Color(0, 0, 0, i);
                    yield return null;
                }
            }
        }
    }
}
