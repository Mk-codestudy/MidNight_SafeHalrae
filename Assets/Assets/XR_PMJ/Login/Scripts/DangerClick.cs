using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerClick : MonoBehaviour
{
    public Camera camera;
    public float rayDistance = 5f;
    public GameObject warningImage;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("Danger"))
                {
                    Debug.Log("Danger");

                    if (warningImage != null)
                    {
                        warningImage.SetActive(true);
                        //StartCoroutine((HideWaringImageAfterDelay(2f))); // 2초 뒤에 꺼지는 코드, 클릭할 때 까지 켜져 있거나 하면 그거는 수정해야됨.
                    }
                    
                }
            }
        }
    }

    IEnumerator HideWaringImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (warningImage != null)
        {
            warningImage.SetActive(false);
        }
    }
}
