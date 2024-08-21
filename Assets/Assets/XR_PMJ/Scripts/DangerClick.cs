using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DangerClick : MonoBehaviour
{
    public Camera mainCamera;
    public float rayDistance = 5f;
    public Image warningImage;

    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("Danger"))
                {
                    Debug.Log("Danger");

                    // 경고 이미지를 활성화한 후, Fadein 코루틴을 두 번 호출
                    warningImage.gameObject.SetActive(true);
                    StartCoroutine(FadeInAndOut(warningImage));
                }
            }
        }
    }

    private IEnumerator FadeInAndOut(Image image)
    {
        // Fadein 코루틴을 두 번 호출
        yield return StartCoroutine(Fadein(image)); // 첫 번째 Fadein
        yield return new WaitForSeconds(0.5f); // 두 번째 Fadein 전 대기 시간 (필요에 따라 조절)
        yield return StartCoroutine(Fadein(image)); // 두 번째 Fadein
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
}