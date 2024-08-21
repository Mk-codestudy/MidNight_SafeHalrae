using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{
    [Header("카메라 로테이션 각도")]
    [Range(5f, 40f)]
    public float rotationAngle = 15f; // 좌우로 기울일 각도
    [Header("카메라 움직임 소요 시간")]
    public float duration = 1f; // 기울이는 데 걸리는 시간
    [Header("카메라 대기 시간")]
    public float waitTime = 2f; // 좌우 끝에서 대기 시간

    void Start()
    {
        StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        Quaternion originalRotation = transform.rotation; // 초기 카메라 회전값
        Quaternion leftRotation = Quaternion.Euler(0f, -rotationAngle, 0f) * originalRotation; // 좌로 15도 회전
        Quaternion rightRotation = Quaternion.Euler(0f, rotationAngle, 0f) * originalRotation; // 우로 15도 회전

        while (true)
        {
            // 좌로 회전
            yield return StartCoroutine(RotateTo(originalRotation, leftRotation, duration));
            // 좌측 끝에서 2초 대기
            yield return new WaitForSeconds(waitTime);

            // 원래 위치로 돌아옴
            yield return StartCoroutine(RotateTo(leftRotation, originalRotation, duration));

            // 우로 회전
            yield return StartCoroutine(RotateTo(originalRotation, rightRotation, duration));
            // 우측 끝에서 2초 대기
            yield return new WaitForSeconds(waitTime);

            // 원래 위치로 돌아옴
            yield return StartCoroutine(RotateTo(rightRotation, originalRotation, duration));
        }
    }

    IEnumerator RotateTo(Quaternion fromRotation, Quaternion toRotation, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, elapsedTime / duration);
            yield return null;
        }

        transform.rotation = toRotation; // 마지막 위치 정확히 맞추기
    }
}