using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DangerDesk : MonoBehaviour
{
    public GameObject sharp;
    public float interactionDistance = 4f;
    public 

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
                print("��ȣ�ۿ� üũ");
                
                
            }
        }

    }
}
