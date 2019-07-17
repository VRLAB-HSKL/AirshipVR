using HTC.UnityPlugin.Vive;
using UnityEngine;

/// <summary>
/// Berechnet anhand einer Kollision die Winkelaenderung fuer das SteeringWheel.
/// </summary>
public class SteeringWheelCollider : MonoBehaviour
{
    Vector3 otherCollider;

    float deltaAngle = 0f;

    public float GetDeltaAngle
    {
        get
        {
            return deltaAngle;
        }
    }

    float actualAngle = 0f;

    Vector3 oldVector;

    Vector3 newVector;

    bool grabbed = false;

    void Start()
    {
        oldVector = Vector3.up;
    }

    void Update()
    {
        if (otherCollider != Vector3.zero && grabbed)
        {
            newVector = new Vector3(otherCollider.x - transform.position.x,
            otherCollider.y - transform.position.y, 0f).normalized;

            deltaAngle = Vector3.SignedAngle(oldVector, newVector, Vector3.forward);

            actualAngle += deltaAngle;

            oldVector = newVector;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            bool triggerPressed = ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger) ^ ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Trigger);

            if (!triggerPressed)
            {
                grabbed = false;
                deltaAngle = 0f;

            } else if (triggerPressed && !grabbed)
            {
                grabbed = true;

                oldVector = new Vector3(otherCollider.x - transform.position.x,
                    otherCollider.y - transform.position.y, 0f).normalized;
            }

            otherCollider = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            grabbed = false;
            deltaAngle = 0f;
            otherCollider = Vector3.zero;
        }
    }
}
