using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship : MonoBehaviour
{
    [SerializeField]
    [Range(.2f, 1f)]
    float oscillationRange = .4f;

    [SerializeField]
    [Range(.04f, .1f)]
    float oscillationTime = .04f;

    [SerializeField]
    float eventRange = 20f;
    [SerializeField]
    float flightHeight = 50f;

    [SerializeField]
    [Range(0f, 2f)]
    float speedForward = 1f;
    [SerializeField]
    [Range(1f, 2f)]
    float speedVertical = 1f;

    [SerializeField]
    [Range(0f, .1f)]
    float rotationSpeed = .1f;

    [SerializeField] SteeringWheel steeringWheel;
    [SerializeField]
    [Range(-2f, 2f)]
    float steer = 0;

    [SerializeField]
    bool lift = false;
    [SerializeField]
    bool fall = false;

    [SerializeField]
    Transform ship;

    [SerializeField]
    Oven oven;

    [SerializeField]
    Ventilation ventilation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, flightHeight - eventRange - (transform.position.y - ship.transform.position.y), flightHeight + eventRange), transform.position.z);
                fall = false;
            }
            if (fall)
            {
                transform.position -= new Vector3(0f, speedVertical * Time.deltaTime, 0f);
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, flightHeight - eventRange - (transform.position.y - ship.transform.position.y), flightHeight + eventRange), transform.position.z);

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
