using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어의 이동 방향
    Vector3 dir;

    // 플레이어의 이동 속도
    public float moveSpeed = 2f;
    // 플레이어의 뛰는 속도
    public float runSpeed = 10f;
    // 플레이어의 걷는 속도
    public float walkSpeed = 5f;

    // 캐릭터 컨트롤러
    CharacterController cc;
    // 중력
    float gravity = -9.81f;
    // y 방향 속력
    float yVelocity;
    // 현재 점프 횟수
    int jumpCurrCnt;
    // 최대 점프 횟수
    int jumpMaxCnt = 2;
    // 점프 힘
    float jumpPower = 3f;

    // 움직이고 있는지 판별
    bool isMoving = false;

    

    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 컨트롤러
        cc = GetComponent<CharacterController>();

        // 이동속력을 걷는 속력으로 설정
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 이동
        WASD_Move();

        // 플레이어 대쉬
        WalkRun();
    }
   
    // 플레이어 이동
    void WASD_Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dirV = transform.forward * v;
        Vector3 dirH = transform.right * h;
        Vector3 dir = dirV + dirH;

        // 움직이고 있는지 판별하자
        isMoving = dir.sqrMagnitude > 0;

        dir.Normalize();

        //transform.position += dir * moveSpeed * Time.deltaTime;
        // 캐릭터가 땅에 있으면
        if(cc.isGrounded)
        {
            // yVelocity 0으로 초기화
            yVelocity = 0;
            jumpCurrCnt = 0;
        }

        // 스페이스바를 누르면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 플레이어가 점프한다.
            if (jumpCurrCnt < jumpMaxCnt)
            {
                // yVelocity에 jumpPower를 셋팅한다.
                yVelocity = jumpPower;
                jumpCurrCnt++;
            }
        }
        // 점프 끝나고 나면 중력값을 이용해서 감소시킨다.
        yVelocity += gravity * Time.deltaTime;
        // dir.y 값에 yVelocity 셋팅
        dir.y = yVelocity;

        // 캐릭터 컨트롤러를 이용해서 걷는다.
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

    // 플레이어 대쉬
    void WalkRun()
    {
        // 왼쪽 Shift 키를 누르면 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWalkRun(true);
        }
        // 왼쪽 Shift 키를 떼면
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetWalkRun(false);
        }
    }

    public void SetWalkRun(bool isRun)
    {
        // isRun 에 따라서 MoveSpeed 변경
        moveSpeed = isRun ? runSpeed : moveSpeed;
    }


}
