using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public float fadeDuration = 1f;
    public int repeatCount = 2;

    private void Start()
    {
        StartCoroutine(FadeInAndOut());
        
    }

    private IEnumerator FadeInAndOut()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            yield return StartCoroutine(Fade(0f, fadeDuration)); // 연해짐

            yield return StartCoroutine(Fade(1f, fadeDuration)); // 진해짐

        }
    }

    private IEnumerator Fade(float targetAlpha, float duration)
    {
        float startAlpha = CanvasGroup.alpha;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(time / duration);
            CanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            yield return null;
        }

        CanvasGroup.alpha = targetAlpha;
    }
}
