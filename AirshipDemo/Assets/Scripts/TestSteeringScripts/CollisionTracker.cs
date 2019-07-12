using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    [SerializeField]
    Vector3 otherCollider;

    [SerializeField]
    Vector3 newUp;

    [SerializeField]
    bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
        {
            grabbed = false;
        }

        if (otherCollider != null && grabbed == true)
        {
            Vector3 offset = (transform.position - otherCollider).normalized;

            float offsetAngle = Vector3.SignedAngle(transform.up, offset, Vector3.forward);

            newUp = new Vector3(offset.magnitude * Mathf.Cos(offsetAngle), offset.magnitude * Mathf.Sin(offsetAngle), 0f);

            transform.up = newUp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            {
                grabbed = true;

                // and controller is null
                otherCollider = other.transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            grabbed = false;
        }
    }
}
