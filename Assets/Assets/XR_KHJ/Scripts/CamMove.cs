using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // ī�޶� ����ٴ� Ÿ�� ����
    public GameObject Target;
    
    // x��ǥ
    public float offsetX = 0.0f;
    // y��ǥ
    public float offsetY = 10.0f;
    // z��ǥ
    public float offsetZ = -10.0f;

    // ī�޶��� �ӵ�
    public float CameraSped = 10.0f;
    // Ÿ�� ��ġ
    Vector3 TargetPos;

    // ȸ�� �ӷ�
    float rotSpeed = 200;
    // ȸ�� ���
    public bool useRotY;
    public bool useRotX;
    // ȸ�� ��
    float rotY;
    float rotX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �����Ӱ��� �޾ƿ´�.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // ȸ�� ������ ����
        if (useRotY) rotY += mx * rotSpeed * Time.deltaTime;
        if (useRotX) rotX += my * rotSpeed * Time.deltaTime;

        // rotX �� ���� -80 ~ 80 ���� ���� (�ּҰ�, �ִ밪)
        rotX = Mathf.Clamp(rotX, -50, 50);
        rotY = Mathf.Clamp(rotY, -180, 180);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);


        // ��ü�� ȸ�� ������ ���� ����.
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);


        //// Ÿ�� ��ġ�� ����
        //TargetPos = new Vector3(
        //    Target.transform.position.x + offsetX,
        //    Target.transform.position.y + offsetY,
        //    Target.transform.position.z + offsetZ
        //    );

        //// ī�޶��� �������� �ε巴�� �Ѵ�.
        //transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSped);

    }
    
}
