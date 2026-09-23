using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashOnEnable : MonoBehaviour
{
    public float flashTime = 0.2f;
    public int flashCount = 10; 
    Image img;

    void OnEnable()
    {
        img = GetComponent<Image>();
        StartCoroutine(FlashMultiple());
    }

    IEnumerator FlashMultiple()
    {
        for (int i = 0; i < flashCount; i++)
        {
            img.enabled = true;
            yield return new WaitForSecondsRealtime(flashTime);

            img.enabled = false;
            yield return new WaitForSecondsRealtime(flashTime);
        }
    }
}
