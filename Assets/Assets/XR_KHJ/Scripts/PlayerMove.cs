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
    public float jumpPower = 3f;

    // 움직이고 있는지 판별
    bool isMoving = false;

    // Animation
    Animator anim;

    float speedValue = 1;

    // 뛰는 상태와 시간 측정 변수
    private bool isRunning = false;
    private float runningTime = 0f;
    public float warningThreshold = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 컨트롤러
        cc = GetComponent<CharacterController>();

        // 이동속력을 걷는 속력으로 설정
        moveSpeed = walkSpeed;

        // Animator
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 이동
        WASD_Move();

        // 플레이어 대쉬
        WalkRun();

        // 플레이어가 대쉬 중인지 체크
        CheckRunning();
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

        // Shift 누르면 속도값 2배
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWalkRun(true);
            speedValue = 2f;
            isRunning = true;
            //print("화면 나오나");
        }
        // Shift 떼면 속도값 1배(원위치한다)
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetWalkRun(false);
            speedValue = 1f;
            isRunning = false;
            runningTime = 0f;
            //print("화면 꺼진다");
        }

        // 플레이어 애니메이션
        anim.SetFloat("Speed", dir.sqrMagnitude * speedValue);

        //transform.position += dir * moveSpeed * Time.deltaTime;
        // 캐릭터가 땅에 있으면
        if (cc.isGrounded)
        {
            // yVelocity 0으로 초기화
            yVelocity = 0;
            jumpCurrCnt = 0;

            anim.SetFloat("JumpPose", 0f);
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

                anim.SetFloat("JumpPose", 1f);
                //anim.SetFloat("Speed", 0f);
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


    bool isScreen = false;

    // 뛰고 있는지 체크한다
    void CheckRunning()
    {
        if(isRunning)
        {
            runningTime += Time.deltaTime;

            if(runningTime >= warningThreshold)
            {
                if(!isScreen)
                {
                    // 화면 보여주기
                    print("화면 나와라");

                    isScreen = true;
                }
                
            }
        }
    }


}
