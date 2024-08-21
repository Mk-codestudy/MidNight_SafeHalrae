using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DangerDesk : MonoBehaviour
{
    public GameObject sharp;
    public float interactionDistance = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 샤프랑 플레이어 상호작용

        // 샤프와 플레이어의 거리 구하기
        float distanceToPlayer = Vector3.Distance(sharp.transform.position, transform.position);

        // 샤프랑 플레이어의 거리가 상호작용 거리보다 커지면
        if (distanceToPlayer > interactionDistance)
        {
            // UI 비활성화

            return;
        }
        else
        {
            // UI 활성화

            if(Input.GetKeyDown(KeyCode.E))
            {
                print("상호작용 체크");
            }
        }

    }
}
