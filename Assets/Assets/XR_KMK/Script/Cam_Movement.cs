using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Movement : MonoBehaviour
{
    [Header("ī�޶� �����̼� ����")]
    [Range(5f, 40f)]
    public float rotationAngle = 15f; // �¿�� ����� ����
    [Header("ī�޶� ������ �ҿ� �ð�")]
    public float duration = 1f; // ����̴� �� �ɸ��� �ð�
    [Header("ī�޶� ��� �ð�")]
    public float waitTime = 2f; // �¿� ������ ��� �ð�

    void Start()
    {
        StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        Quaternion originalRotation = transform.rotation; // �ʱ� ī�޶� ȸ����
        Quaternion leftRotation = Quaternion.Euler(0f, -rotationAngle, 0f) * originalRotation; // �·� 15�� ȸ��
        Quaternion rightRotation = Quaternion.Euler(0f, rotationAngle, 0f) * originalRotation; // ��� 15�� ȸ��

        while (true)
        {
            // �·� ȸ��
            yield return StartCoroutine(RotateTo(originalRotation, leftRotation, duration));
            // ���� ������ 2�� ���
            yield return new WaitForSeconds(waitTime);

            // ���� ��ġ�� ���ƿ�
            yield return StartCoroutine(RotateTo(leftRotation, originalRotation, duration));

            // ��� ȸ��
            yield return StartCoroutine(RotateTo(originalRotation, rightRotation, duration));
            // ���� ������ 2�� ���
            yield return new WaitForSeconds(waitTime);

            // ���� ��ġ�� ���ƿ�
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

        transform.rotation = toRotation; // ������ ��ġ ��Ȯ�� ���߱�
    }
}