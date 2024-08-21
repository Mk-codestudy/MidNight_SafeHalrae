using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerRay : MonoBehaviour
{
    public Camera mainCamera;
    public float rayDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    print("위험해!");

                    //wimage.SetActive(true); // 경고 이미지 활성화
                    //StartCoroutine(Fadein(warningImage)); // 2초 후에 숨기기
                }
            }
        }
    }

    //public IEnumerator Fadein(Image blackout)
    //{
    //    Color fadeColor = blackout.color;
    //    for (int i = 0; i < 50; i++)
    //    {
    //        fadeColor.a += 0.02f;
    //        blackout.color = fadeColor;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    yield return new WaitForSeconds(2f);

    //    for (int i = 0; i < 100; i++)
    //    {
    //        fadeColor.a -= 0.02f;
    //        blackout.color = fadeColor;
    //        yield return new WaitForSeconds(0.01f);
    //    }

    //    yield return null;
    //}

    //IEnumerator HideWarningImageAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    if (warningImage != null && fadeImageScript != null)
    //    {
    //        StartCoroutine(fadeImageScript.Fadein(warningImage));
    //    }
    //}
}
