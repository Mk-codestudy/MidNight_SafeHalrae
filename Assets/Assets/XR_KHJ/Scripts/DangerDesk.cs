using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DangerDesk : MonoBehaviour
{
    public GameObject sharp;
    public float interactionDistance = 4f;
    public DangerClick DangerClick;

    [Header("안전이 통신용 변수")]
    public HttpManager hp;

    [Header("랜덤 질문용 리스트")]
    public List<string> randomquest = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ������ �÷��̾� ��ȣ�ۿ�

        // ������ �÷��̾��� �Ÿ� ���ϱ�
        float distanceToPlayer = Vector3.Distance(sharp.transform.position, transform.position);

        // ������ �÷��̾��� �Ÿ��� ��ȣ�ۿ� �Ÿ����� Ŀ����
        if (distanceToPlayer > interactionDistance)
        {
            // UI ��Ȱ��ȭ
            
    
            return;
        }
        else
        {
            // UI Ȱ��ȭ

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (DangerClick != null)
                {
                    print("연필");

                    DangerClick.TriggerDangerCilck();
                    hp.aiSafy[1] = "교실";
                    hp.aiSafy[2] = randomquest[(Random.Range(0, 3))];
                    hp.SafyStartTalk();
                }
            }
        }

    }
}
