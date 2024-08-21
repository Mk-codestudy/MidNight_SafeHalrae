using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRay : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 3.0f;
    public float minDistance = 1.0f;
    public LayerMask layerMask;
    public float cameraSmoothSpeed = 10.0f;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3(0, 2, -distanceFromPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라의 목표 위치 계산 (플레이어의 뒤쪽 일정 거리)
        Vector3 desiredCameraPosition = player.position + player.TransformDirection(cameraOffset);

        // 레이캐스트로 플레이어와 카메라 사이에 충돌체가 있는지 확인
        RaycastHit hit;
        if (Physics.Linecast(player.position, desiredCameraPosition, out hit, layerMask))
        {
            // 충돌이 감지되면 카메라를 충돌 위치로 이동 (충돌체와 플레이어 사이의 거리를 유지)
            float distanceToObstacle = Vector3.Distance(player.position, hit.point) - 0.5f; // 약간의 여유를 줌
            desiredCameraPosition = player.position + player.TransformDirection(cameraOffset.normalized * Mathf.Clamp(distanceToObstacle, minDistance, distanceFromPlayer));
        }

        // 카메라를 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredCameraPosition, cameraSmoothSpeed * Time.deltaTime);

        // 카메라가 항상 플레이어를 바라보도록 함
        transform.LookAt(player.position + Vector3.up * 1.5f);  // 약간의 오프셋 추가
    }
}
