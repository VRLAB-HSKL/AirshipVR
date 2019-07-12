using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    TestCollider collider;

    [SerializeField]
    float actualAngle = 0f;

    [SerializeField]
    float maxAngle = 720f;

    [SerializeField]
    float stearingValue = 0f;

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
        }else if (collider.GetDeltaAngle != 0f
            && (actualAngle + collider.GetDeltaAngle <= -maxAngle
            || actualAngle + collider.GetDeltaAngle >= maxAngle))
        {
            if (actualAngle < 0)
            {
                actualAngle = -maxAngle;
                // rumble
            }else
            {
                actualAngle = maxAngle;
                // rumble
            }
        }

        stearingValue = -actualAngle * (maxAngle / 360) / maxAngle;

        transform.rotation = Quaternion.Euler(0f, 0f, actualAngle);
    }
}
