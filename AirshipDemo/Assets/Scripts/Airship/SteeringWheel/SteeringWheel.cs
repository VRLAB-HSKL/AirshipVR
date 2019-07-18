using UnityEngine;

/// <summary>
/// Verwendet den Differenzwinkel von einem SteeringWheelCollider, um den neuen Winkel fuer das Steuerrad zu berechnen und dieses auszurichten.
/// Liefert einen Wert fuer das Airship, der dessen Rotationsgeschwindigkeit beeinflusst.
/// </summary>
public class SteeringWheel : MonoBehaviour
{
    [SerializeField] new SteeringWheelCollider collider;

    [SerializeField] float maxAngle = 720f;

    float oldAngle = 0f;
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
        float deltaAngle = collider.GetDeltaAngle;

        if (deltaAngle != 0f
            && !(actualAngle + deltaAngle <= -maxAngle
            || actualAngle + deltaAngle >= maxAngle))
        {
            actualAngle += deltaAngle;
        }
        else if (deltaAngle != 0f
           && (actualAngle + deltaAngle <= -maxAngle
           || actualAngle + deltaAngle >= maxAngle))
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

        // Setzt den Winkel bei Aenderungen ausserhalb des Limits zurueck / Feinabstimmung fuer Steuerrad
        if (Mathf.Abs(actualAngle - oldAngle) > 10f)
        {
            actualAngle = oldAngle;
        }

        steeringValue = -actualAngle * (maxAngle / 360) / maxAngle;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, actualAngle);

        oldAngle = actualAngle;
    }
}
