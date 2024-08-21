using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCollider : MonoBehaviour
{
    public DangerClick DangerClick;

    [Header("안전이 통신용 변수")]
    public HttpManager hp;

    [Header("랜덤 질문용 리스트")]
    public List<string> randomquest = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // �����Ҷ� UI ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // ���� �÷��̾ ��ܰ� �浹��
        if (other.CompareTag("Danger"))
        {
            print("계단");
            // ���� UI Ȱ��ȭ
            if (DangerClick != null)
            {
                //DangerClick.TriggerDangerCilck();
            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �浹 �������� ��� ��� 
        if (other.CompareTag("Danger"))
        {
            print("��ܿ��� �����");
            //���� UI ��Ȱ��ȭ
            DangerClick.TriggerDangerCilck();
            hp.aiSafy[1] = "주행";
            hp.aiSafy[2] = randomquest[(Random.Range(0, 3))];
            hp.SafyStartTalk();
        }
    }
}
