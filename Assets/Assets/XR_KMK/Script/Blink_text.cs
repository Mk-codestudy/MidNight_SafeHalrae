using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink_text : MonoBehaviour
{
    public Text text;
    public float duration = 0.5f;
    void Start()
    {
        StartCoroutine(AnimateTextAlbedo());
    }

    IEnumerator AnimateTextAlbedo()
    {
        while (true)
        {
            // 0.5초 동안 알파 값을 255에서 0으로 변경
            yield return StartCoroutine(FadeAlpha(1f, 0f, duration));

            // 0.5초 동안 알파 값을 0에서 255으로 변경
            yield return StartCoroutine(FadeAlpha(0f, 1f, duration));

            // 0.5초 동안 알파 값을 유지 (255)
            yield return new WaitForSeconds(duration);
        }
    }

    IEnumerator FadeAlpha(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = text.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // 최종 알파 값 설정
        text.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
