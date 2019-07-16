using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipButton : MonoBehaviour
{
    [SerializeField]
    Transform button;

    [SerializeField]
    AirshipButtonCollider collider;

    [SerializeField]
    Vector3 upPosition;

    [SerializeField]
    Vector3 downPosition;

    [SerializeField]
    ParticleSystem flames;

    [SerializeField]
    float range = 0f;

    [SerializeField]
    bool pressed = false;

    public bool IsPressed
    {
        get
        {
            return pressed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        upPosition = button.transform.localPosition;
        downPosition = button.transform.localPosition - Vector3.up * range;
    }

    // Update is called once per frame
    void Update()
    {
        pressed = collider.IsPressed;

        if (pressed)
        {
            button.transform.localPosition = downPosition;
        }
        else
        {
            button.transform.localPosition = upPosition;

        }
    }
}
