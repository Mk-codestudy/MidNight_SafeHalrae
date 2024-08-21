using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRay : MonoBehaviour
{
    // 따라가야 할 오브젝트 정보
    public Transform objectToFollow;
    // 따라갈 스피드
    public float followSpeed = 10f;
  
    // 카메라의 정보도
    public Transform realCamera;
    // 방향
    public Vector3 dirNomalized;
    // 정해진 방향을 저장해주는 변수
    public Vector3 finalDir;
    // 최소 거리
    public float minDistance;
    // 최대 거리
    public float maxDistance;

    // 최종적으로 결정된 거리
    public float finalDistance;
    public float smoothness = 10f;

    //  레이어 마스크
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
