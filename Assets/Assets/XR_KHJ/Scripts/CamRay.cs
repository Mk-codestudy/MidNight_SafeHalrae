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
        // ī�޶��� ��ǥ ��ġ ��� (�÷��̾��� ���� ���� �Ÿ�)
        Vector3 desiredCameraPosition = player.position + player.TransformDirection(cameraOffset);

        // ����ĳ��Ʈ�� �÷��̾�� ī�޶� ���̿� �浹ü�� �ִ��� Ȯ��
        RaycastHit hit;
        if (Physics.Linecast(player.position, desiredCameraPosition, out hit, layerMask))
        {
            // �浹�� �����Ǹ� ī�޶� �浹 ��ġ�� �̵� (�浹ü�� �÷��̾� ������ �Ÿ��� ����)
            float distanceToObstacle = Vector3.Distance(player.position, hit.point) - 0.5f; // �ణ�� ������ ��
            desiredCameraPosition = player.position + player.TransformDirection(cameraOffset.normalized * Mathf.Clamp(distanceToObstacle, minDistance, distanceFromPlayer));
        }

        // ī�޶� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredCameraPosition, cameraSmoothSpeed * Time.deltaTime);

        // ī�޶� �׻� �÷��̾ �ٶ󺸵��� ��
        transform.LookAt(player.position + Vector3.up * 1.5f);  // �ణ�� ������ �߰�
    }
}
