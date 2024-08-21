using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerClick : MonoBehaviour
{
    public Camera mainCamera;
    public float rayDistance = 5f;
    public Image warningImage;
    public GameObject otherUI;

    [Header("파티클 실행 변수")]
    public GameObject particleActive;

    //[Header("안전이 통신용 변수")]
    //public HttpManager hp;

    //[Header("랜덤 질문용 리스트")]
    //public List<string> randomquest = new List<string>();

    public void TriggerDangerCilck()
    {
        particleActive.SetActive(true);
        StartCoroutine(FadeInAndOutCoroutine());
    }

    public IEnumerator FadeInAndOutCoroutine()
    {
        // Fadein 코루틴을 두 번 호출
        yield return StartCoroutine(Fadein(warningImage)); // 첫 번째 Fadein
        yield return new WaitForSeconds(0.5f); // 두 번째 Fadein 전 대기 시간 (필요에 따라 조절)
        yield return StartCoroutine(Fadein(warningImage)); // 두 번째 Fadein
        particleActive.SetActive(false);
        ShowotherUI();
    }

    private IEnumerator Fadein(Image blackout)
    {
        Color fadeColor = blackout.color;
        // 서서히 나타나기
        for (int i = 0; i < 100; i++)
        {
            fadeColor.a += 0.01f;
            blackout.color = fadeColor;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.1f); // 밝아진 후 잠시 대기

        // 서서히 사라지기
        for (int i = 0; i < 100; i++)
        {
            fadeColor.a -= 0.01f;
            blackout.color = fadeColor;
            yield return new WaitForSeconds(0.005f);
        }
    }

    private void ShowotherUI()
    {
        if (otherUI != null)
        {
            Debug.Log("켜졌지롱!");
            otherUI.SetActive(true);

        }
    }
}