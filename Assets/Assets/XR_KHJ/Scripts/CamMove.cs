using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // 카메라가 따라다닐 타겟 설정
    public GameObject Target;
    
    // x좌표
    public float offsetX = 0.0f;
    // y좌표
    public float offsetY = 10.0f;
    // z좌표
    public float offsetZ = -10.0f;

    // 카메라의 속도
    public float CameraSped = 10.0f;
    // 타겟 위치
    Vector3 TargetPos;

    // 회전 속력
    float rotSpeed = 200;
    // 회전 허용
    public bool useRotY;
    public bool useRotX;
    // 회전 값
    float rotY;
    float rotX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 움직임값을 받아온다.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // 회전 각도를 누적
        if (useRotY) rotY += mx * rotSpeed * Time.deltaTime;
        if (useRotX) rotX += my * rotSpeed * Time.deltaTime;

        // rotX 의 값의 -80 ~ 80 도로 제한 (최소값, 최대값)
        rotX = Mathf.Clamp(rotX, -50, 50);
        rotY = Mathf.Clamp(rotY, -180, 180);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);


        // 물체를 회전 각도로 셋팅 하자.
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);


        //// 타겟 위치점 지정
        //TargetPos = new Vector3(
        //    Target.transform.position.x + offsetX,
        //    Target.transform.position.y + offsetY,
        //    Target.transform.position.z + offsetZ
        //    );

        //// 카메라의 움직임을 부드럽게 한다.
        //transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSped);

    }
    
}
