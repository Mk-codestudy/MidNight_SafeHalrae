using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float amplitude = 1.0f; // �������� ����
    public float frequency = 1.0f; // �������� �ӵ�

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(0, y, 0);
    }
}