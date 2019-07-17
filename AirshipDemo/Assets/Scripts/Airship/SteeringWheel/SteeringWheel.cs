using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    [SerializeField]
    SteeringWheelCollider collider;

    [SerializeField]
    float actualAngle = 0f;

    [SerializeField]
    float maxAngle = 720f;

    [SerializeField]
    [Range(-2f, 2f)]
    float steeringValue = 0f;

    public float GetSteeringValue
    {
        get
        {
            return steeringValue;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collider.GetDeltaAngle != 0f
            && !(actualAngle + collider.GetDeltaAngle <= -maxAngle
            || actualAngle + collider.GetDeltaAngle >= maxAngle))
        {
            actualAngle += collider.GetDeltaAngle;
        }
        else if (collider.GetDeltaAngle != 0f
           && (actualAngle + collider.GetDeltaAngle <= -maxAngle
           || actualAngle + collider.GetDeltaAngle >= maxAngle))
        {
            if (actualAngle < 0)
            {
                actualAngle = -maxAngle;
                // rumble
            }
            else
            {
                actualAngle = maxAngle;
                // rumble
            }
        }

        steeringValue = -actualAngle * (maxAngle / 360) / maxAngle;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, actualAngle);
    }
}
