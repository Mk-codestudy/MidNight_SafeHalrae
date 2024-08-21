using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾��� �̵� ����
    Vector3 dir;

    // �÷��̾��� �̵� �ӵ�
    public float moveSpeed = 2f;
    // �÷��̾��� �ٴ� �ӵ�
    public float runSpeed = 10f;
    // �÷��̾��� �ȴ� �ӵ�
    public float walkSpeed = 5f;
    public DangerClick DangerClick;

    // ĳ���� ��Ʈ�ѷ�
    CharacterController cc;
    // �߷�
    float gravity = -9.81f;
    // y ���� �ӷ�
    float yVelocity;
    // ���� ���� Ƚ��
    int jumpCurrCnt;
    // �ִ� ���� Ƚ��
    int jumpMaxCnt = 2;
    // ���� ��
    public float jumpPower = 3f;

    // �����̰� �ִ��� �Ǻ�
    bool isMoving = false;

    // Animation
    Animator anim;

    float speedValue = 1;

    // �ٴ� ���¿� �ð� ���� ����
    private bool isRunning = false;
    private float runningTime = 0f;
    public float warningThreshold = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        // ĳ���� ��Ʈ�ѷ�
        cc = GetComponent<CharacterController>();

        // �̵��ӷ��� �ȴ� �ӷ����� ����
        moveSpeed = walkSpeed;

        // Animator
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� �̵�
        WASD_Move();

        // �÷��̾� �뽬
        WalkRun();

        // �÷��̾ �뽬 ������ üũ
        CheckRunning();
    }
   
    // �÷��̾� �̵�
    void WASD_Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dirV = transform.forward * v;
        Vector3 dirH = transform.right * h;
        Vector3 dir = dirV + dirH;

        // �����̰� �ִ��� �Ǻ�����
        isMoving = dir.sqrMagnitude > 0;
        dir.Normalize();

        // Shift ������ �ӵ��� 2��
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWalkRun(true);
            speedValue = 2f;
            isRunning = true;
            //print("ȭ�� ������");
        }
        // Shift ���� �ӵ��� 1��(����ġ�Ѵ�)
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetWalkRun(false);
            speedValue = 1f;
            isRunning = false;
            runningTime = 0f;
            //print("ȭ�� ������");
        }

        // �÷��̾� �ִϸ��̼�
        anim.SetFloat("Speed", dir.sqrMagnitude * speedValue);

        //transform.position += dir * moveSpeed * Time.deltaTime;
        // ĳ���Ͱ� ���� ������
        if (cc.isGrounded)
        {
            // yVelocity 0���� �ʱ�ȭ
            yVelocity = 0;
            jumpCurrCnt = 0;

            anim.SetFloat("JumpPose", 0f);
        }

        // �����̽��ٸ� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �÷��̾ �����Ѵ�.
            if (jumpCurrCnt < jumpMaxCnt)
            {
                // yVelocity�� jumpPower�� �����Ѵ�.
                yVelocity = jumpPower;
                jumpCurrCnt++;

                anim.SetFloat("JumpPose", 1f);
                //anim.SetFloat("Speed", 0f);
            }
        }
     
        // ���� ������ ���� �߷°��� �̿��ؼ� ���ҽ�Ų��.
        yVelocity += gravity * Time.deltaTime;
        // dir.y ���� yVelocity ����
        dir.y = yVelocity;

        // ĳ���� ��Ʈ�ѷ��� �̿��ؼ� �ȴ´�.
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

    // �÷��̾� �뽬
    void WalkRun()
    {
        // ���� Shift Ű�� ������ 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetWalkRun(true);
        }
        // ���� Shift Ű�� ����
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetWalkRun(false);
        }
    }

    public void SetWalkRun(bool isRun)
    {
        // isRun �� ���� MoveSpeed ����
        moveSpeed = isRun ? runSpeed : moveSpeed;
    }


    bool isScreen = false;

    // �ٰ� �ִ��� üũ�Ѵ�
    void CheckRunning()
    {
        if(isRunning)
        {
            runningTime += Time.deltaTime;

            if(runningTime >= warningThreshold)
            {
                if(!isScreen)
                {
                    // ȭ�� �����ֱ�
                    print("ȭ�� ���Ͷ�");

                    isScreen = true;
                    DangerClick.TriggerDangerCilck();
                }
                
            }
        }
    }


}
