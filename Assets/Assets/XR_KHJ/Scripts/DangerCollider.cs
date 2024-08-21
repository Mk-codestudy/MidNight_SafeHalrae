using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 시작할때 UI 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // 만약 플레이어가 계단과 충돌시
        if (other.CompareTag("Danger"))
        {
            print("계단에서 넘어진다");
            // 위험 UI 활성화
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 충돌 영역에서 벗어날 경우 
        if (other.CompareTag("Danger"))
        {
            print("계단에서 벗어나라");
            //위험 UI 비활성화

        }
    }
}
