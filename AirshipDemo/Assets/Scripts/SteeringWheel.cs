using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    [SerializeField]
    [Range(-720f, 720f)]
    float actualAngle = 0f;

    [SerializeField]
    [Range(0, 1080f)]
    float maxAngle = 720;

    [SerializeField]
    float deltaAngle = 0f;

    [SerializeField]
    Vector3 oldVector;

    [SerializeField]
    Vector3 newVector;

    [SerializeField]
    float stearingValue = 0f;

    [SerializeField]
    bool locked = false;

    void Start()
    {
        oldVector = Vector3.up;
    }

    void Update()
    {
        newVector = transform.up;

        deltaAngle = Vector3.SignedAngle(oldVector, newVector, Vector3.forward);

        actualAngle += -deltaAngle;

        actualAngle = Mathf.Clamp(actualAngle, -maxAngle, maxAngle);

        oldVector = newVector;

        stearingValue = actualAngle * 2 / maxAngle;
    }

    public float GetStearingValue()
    {
        return stearingValue;
    }

    public void LockedSteeringWheel(bool wheelLocked)
    {
        locked = wheelLocked;
    }
}
