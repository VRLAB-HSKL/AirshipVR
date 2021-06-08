using UnityEngine;

/// <summary>
/// Steuerung des Airships. 
/// </summary>
public class Airship : MonoBehaviour
{
    [SerializeField] SteeringWheel steeringWheel;

    [SerializeField] Transform ship;

    [SerializeField] Oven oven;

    [SerializeField] Ventilation ventilation;

    [SerializeField]
    [Range(.2f, 1f)] float oscillationRange = .4f;

    [SerializeField]
    [Range(.04f, .1f)] float oscillationTime = .04f;

    [SerializeField] float maxHeight = 80f;

    [SerializeField]
    [Range(0f, 5f)] float speedForward = 3f;
    [SerializeField]
    [Range(1f, 5f)] float speedVertical = 3f;

    [SerializeField]
    [Range(0f, .1f)] float rotationSpeed = .1f;

    float steer = 0;

    bool lift = false;
    bool fall = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void Update()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        steer = steeringWheel.GetSteeringValue;

        if (!steer.Equals(0))
        {
            Stear();
        }
        transform.position += transform.forward * speedForward * Time.deltaTime;

        if (!oven.NoFuel)
        {
            lift = oven.IsLifting;
        }

        fall = ventilation.IsFalling;

        if (lift && fall)
        {
            lift = false;
            fall = false;
        }
        else if (lift || fall)
        {
            if (lift)
            {
                transform.position += new Vector3(0f, speedVertical * Time.deltaTime, 0f);
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1f, maxHeight), transform.position.z);
                fall = false;
            }
            if (fall)
            {
                transform.position -= new Vector3(0f, speedVertical * Time.deltaTime, 0f);
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 1f, maxHeight), transform.position.z);

                lift = false;
            }
        }
        else
        {
            Oscillate(oscillationRange);
        }

    }

    void Oscillate(float range)
    {
        ship.transform.localPosition = new Vector3(0f,
            Mathf.PingPong(Time.time * oscillationTime, range),
            0f);
    }

    void Stear()
    {
        float targetRotation = steer * rotationSpeed + transform.eulerAngles.y;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, (Vector3.up * targetRotation).y, 0f), 10f);
    }
}
