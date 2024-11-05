using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Load_Fill : MonoBehaviour
{
    public Image fillImage; 
    public float fillDuration = 1f; 

    private void Start()
    {
        StartCoroutine(AnimateFill());
    }

    private IEnumerator AnimateFill()
    {
        while (true)
        {
            float elapsedTime = 0f;
            while (elapsedTime < fillDuration)
            {
                elapsedTime += Time.deltaTime;
                fillImage.fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);
                yield return null;
            }

            fillImage.fillAmount = 0f;
            yield return null; 
        }
    }
}
