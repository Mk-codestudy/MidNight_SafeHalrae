using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFixed : MonoBehaviour
{
    // 커서가 잠겨있는 상태인지 여부를 확인하는 변수
    private bool isCursorLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        //// 처음 게임 시작 시 커서를 잠그고 숨김
        //LockCursor();
    }

    // Update is called once per frame
    void Update()
    {

        //// ESC 키를 누르면 커서 고정 상태를 풀고 다시 ESC를 누르면 고정
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (isCursorLocked)
        //    {
        //        UnlockCursor();
        //    }
        //    else
        //    {
        //        LockCursor();
        //    }
        //}
    }

    //// 커서를 잠그고 숨기는 함수
    //void LockCursor()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;  // 커서를 화면 중앙에 고정
    //    Cursor.visible = false;  // 커서를 보이지 않게 설정
    //    isCursorLocked = true;  // 상태 업데이트
    //}

    //// 커서를 해제하고 보이게 하는 함수
    //void UnlockCursor()
    //{
    //    Cursor.lockState = CursorLockMode.None;  // 커서 고정 해제
    //    Cursor.visible = true;  // 커서를 보이게 설정
    //    isCursorLocked = false;  // 상태 업데이트
    //}
}
