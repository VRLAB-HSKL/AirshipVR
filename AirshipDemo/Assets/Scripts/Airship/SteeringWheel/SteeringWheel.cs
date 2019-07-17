using UnityEngine;

/// <summary>
/// Verwendet den Differenzwinkel von einem SteeringWheelCollider, um den neuen Winkel fuer das Steuerrad zu berechnen und dieses auszurichten.
/// Liefert einen Wert fuer das Airship, der dessen Rotationsgeschwindigkeit beeinflusst.
/// </summary>
public class SteeringWheel : MonoBehaviour
{
    [SerializeField] new SteeringWheelCollider collider;

    [SerializeField] float maxAngle = 720f;

    float actualAngle = 0f;
    float steeringValue = 0f;

    public float GetSteeringValue
    {
        get
        {
            return steeringValue;
        }
    }

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
            }
            else
            {
                actualAngle = maxAngle;
            }
        }

        steeringValue = -actualAngle * (maxAngle / 360) / maxAngle;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, actualAngle);
    }
}
