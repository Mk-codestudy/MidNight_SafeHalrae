using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerDash : MonoBehaviour
{
    PlayerMove pm;

    // �ٰ� �ִ°�?
    public bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾� ���� ��ũ��Ʈ �����Ѵ�.
        pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // 3�� �̻� �޸��� ��� �߰� �Ѵ�.
    }
}
