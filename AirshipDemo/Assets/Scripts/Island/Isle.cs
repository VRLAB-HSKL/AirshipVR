using UnityEngine;

/// <summary>
/// Steuert die Bewegung einer Isle.
/// </summary>
public class Isle : MonoBehaviour
{
    Vector3 originalPosition;

    float oscillationTime;
    
    float rotationOscillation;

    float xOscillation;
    float yOscillation;
    float zOscillation;

    void Start()
    {
        originalPosition = transform.position;

        oscillationTime = 10f * Time.deltaTime;

        rotationOscillation = Random.Range(0f, 180f);

        xOscillation = Random.Range(0f, 1f);
    }

    void Update()
    {
        OscillatePosition();
        OscillateRotation();
    }

    void OnDisable()
    {
        originalPosition = Vector3.zero;
    }

    void OnEnable()
    {
        originalPosition = transform.position;
    }

    void OscillatePosition()
    {
        Vector3 up = originalPosition + Vector3.up * Mathf.PingPong(Time.time * oscillationTime, xOscillation);
        transform.position = up;
    }

    void OscillateRotation()
    {
        transform.rotation = Quaternion.Euler(0f, Mathf.PingPong(Time.time * oscillationTime, rotationOscillation), 0f);
    }
}
