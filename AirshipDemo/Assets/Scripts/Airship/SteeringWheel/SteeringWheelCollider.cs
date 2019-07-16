using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelCollider : MonoBehaviour
{
    [SerializeField]
    Vector3 otherCollider;

    [SerializeField]
    float offsetAngle;

    [SerializeField]
    float deltaAngle = 0f;

    public float GetDeltaAngle
    {
        get
        {
            return deltaAngle;
        }
    }

    [SerializeField]
    float actualAngle = 0f;

    [SerializeField]
    Vector3 startVector;

    [SerializeField]
    Vector3 oldVector;

    [SerializeField]
    Vector3 newVector;

    [SerializeField]
    bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        oldVector = Vector3.up;
    }

    // Update is called once per frame
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
            if (!ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
            {
                grabbed = false;
                deltaAngle = 0f;

            } else if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger) && !grabbed)
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
        }
    }
}
