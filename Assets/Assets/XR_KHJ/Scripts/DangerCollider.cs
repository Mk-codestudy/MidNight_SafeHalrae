using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCollider : MonoBehaviour
{
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
            print("��ܿ��� �Ѿ�����");
            // ���� UI Ȱ��ȭ
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ �浹 �������� ��� ��� 
        if (other.CompareTag("Danger"))
        {
            print("��ܿ��� �����");
            //���� UI ��Ȱ��ȭ

        }
    }
}
