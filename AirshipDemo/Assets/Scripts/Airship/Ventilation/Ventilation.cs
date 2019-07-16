using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour
{
    [SerializeField]
    AirshipButton button;

    [SerializeField]
    bool fall = false;

    [SerializeField]
    Transform hatch;

    [SerializeField]
    Vector2 range = new Vector2(0f, 90f);

    public bool IsFalling
    {
        get
        {
            return fall;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fall = button.IsPressed;

        if (fall)
        {
            hatch.transform.localRotation = Quaternion.RotateTowards(hatch.transform.localRotation, Quaternion.Euler(0f, 0f, range.y), 10f);
        }
        else
        {
            hatch.transform.localRotation = Quaternion.RotateTowards(hatch.transform.localRotation, Quaternion.Euler(0f, 0f, range.x), 10f);
        }
    }
}
