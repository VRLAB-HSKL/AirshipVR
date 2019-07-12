using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class WheelTest : MonoBehaviour
{
    Transform otherCollider = null;

    [SerializeField]
    Collider wheelCollider;

    [SerializeField]
    float angle = 0;

    [SerializeField]
    bool grabbed = false;

    void Update()
    {
        if (!ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger)) {
            grabbed = false;
        }

        if(otherCollider != null && grabbed == true)
        {
            angle = Mathf.Atan2(otherCollider.position.z, otherCollider.position.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(-90f, 0f, angle);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            if (ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
            {
                grabbed = true;

                // and controller is null
                otherCollider = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            grabbed = false;
            otherCollider = null;
        }
    }
}
