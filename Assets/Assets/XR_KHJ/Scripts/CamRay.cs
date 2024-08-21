using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRay : MonoBehaviour
{
    // ���󰡾� �� ������Ʈ ����
    public Transform objectToFollow;
    // ���� ���ǵ�
    public float followSpeed = 10f;
  
    // ī�޶��� ������
    public Transform realCamera;
    // ����
    public Vector3 dirNomalized;
    // ������ ������ �������ִ� ����
    public Vector3 finalDir;
    // �ּ� �Ÿ�
    public float minDistance;
    // �ִ� �Ÿ�
    public float maxDistance;

    // ���������� ������ �Ÿ�
    public float finalDistance;
    public float smoothness = 10f;

    //  ���̾� ����ũ
    public LayerMask collisionMask;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        realCamera = Camera.main.transform;

        maxDistance = (transform.position - realCamera.position).magnitude;

        Debug.LogError("maxDist :" + maxDistance);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dirToCam = realCamera.position - transform.position;
        dirToCam.Normalize();
        Ray ray = new Ray(transform.position, dirToCam);

        RaycastHit hit;

        LayerMask wallMake = LayerMask.GetMask("Wall");
        if (Physics.Raycast(ray, out hit, maxDistance, wallMake))
        {
            realCamera.transform.position = hit.point;
        }
        else
        {
            realCamera.transform.position = transform.position + dirToCam * maxDistance;
            Debug.Log("maxDist :" + (realCamera.position - transform.position).magnitude);
        }
        


        //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);

        //finalDir = transform.TransformPoint(dirNomalized * maxDistance);

        //RaycastHit hit;

        //if (Physics.Raycast(objectToFollow.position, finalDir, out hit, collisionMask))
        //{
        //    finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        //}
        //else
        //{
        //    finalDistance = maxDistance;
        //}

        //realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNomalized * finalDistance, Time.deltaTime * smoothness);

    }
}
