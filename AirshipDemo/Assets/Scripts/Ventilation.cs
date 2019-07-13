using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour
{
    [SerializeField]
    AirshipButton button;

    [SerializeField]
    bool fall = false;

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
    }
}
