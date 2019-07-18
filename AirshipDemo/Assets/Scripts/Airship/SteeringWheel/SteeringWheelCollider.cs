﻿using HTC.UnityPlugin.Vive;
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

    Vector3 oldVector;

    Vector3 newVector;

    bool grabbed = false;

    void Start()
    {
        oldVector = Vector3.up;
    }

    void FixedUpdate()
    {
        if (otherCollider != Vector3.zero && grabbed)
        {
            newVector = new Vector3(otherCollider.x - transform.position.x,
            otherCollider.y - transform.position.y, 0f).normalized;

            float previewDeltaAngle = Vector3.SignedAngle(oldVector, newVector, Vector3.forward);

            // Feinabstimmung fuer Steuerrad
            if (previewDeltaAngle > 6f || previewDeltaAngle < 6f)
            {
                deltaAngle = previewDeltaAngle;
                oldVector = newVector;
            }
            else
            {
                deltaAngle = 0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            bool triggerPressed = ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger) ^ ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Trigger);

            // Zusaetzliche Einschraenkung des Interaktionsbereichs auf die Hoehe der Griffe des Steuerrads / Feinabstimmung fuer Steuerrad
            if (!triggerPressed || Vector3.Distance(otherCollider, transform.position) < 1f || Vector3.Distance(otherCollider, transform.position) > 1.8f)
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

    // Markiert die Breite des Interaktionsbereichs
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position + Vector3.up, transform.position + Vector3.up * 1.5f);
        Gizmos.DrawLine(transform.position + Vector3.left, transform.position + Vector3.left * 1.5f);
        Gizmos.DrawLine(transform.position + Vector3.right, transform.position + Vector3.right * 1.5f);
        Gizmos.DrawLine(transform.position + Vector3.down, transform.position + Vector3.down  * 1.5f);
    }

}
