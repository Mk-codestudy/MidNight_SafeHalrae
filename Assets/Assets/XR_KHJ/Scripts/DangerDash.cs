using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerDash : MonoBehaviour
{
    PlayerMove pm;

    // 뛰고 있는가?
    public bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 무브 스크립트 참조한다.
        pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // 3초 이상 달리면 경고 뜨게 한다.
    }
}
