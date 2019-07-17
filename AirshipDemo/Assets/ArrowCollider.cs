using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    bool pressed = false;
    public bool IsPressed
    {
        get
        {
            return pressed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pressed = false;
    }
}
