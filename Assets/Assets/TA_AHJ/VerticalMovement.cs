using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float amplitude = 1.0f; // 움직임의 범위
    public float frequency = 1.0f; // 움직임의 속도

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