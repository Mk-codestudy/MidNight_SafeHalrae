using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCollider : MonoBehaviour
{
    public DangerClick DangerClick;
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

        }
    }
}
