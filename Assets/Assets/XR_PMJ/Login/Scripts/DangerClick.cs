using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DangerClick : MonoBehaviour
{
    public Camera mainCamera;
    public float rayDistance = 5f;
    public Image warningImage;
    //public GameObject wimage;
    //private FadeImage fadeImageScript;
    

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
                    
                    //wimage.SetActive(true); // 경고 이미지 활성화
                    StartCoroutine(Fadein(warningImage)); // 2초 후에 숨기기
                }
            }
        }
    }

    public IEnumerator Fadein(Image blackout)
    {
        Color fadeColor = blackout.color;
        for (int i = 0; i < 100; i++)
        {
            fadeColor.a += 0.01f;
            blackout.color = fadeColor;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.1f);
        
        for (int i = 0; i < 100; i++)
        {
            fadeColor.a -= 0.01f;
            blackout.color = fadeColor;
            yield return new WaitForSeconds(0.005f);
        }
        
    }
    
  
}