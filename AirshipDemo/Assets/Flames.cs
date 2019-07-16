using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    [SerializeField]
    AirshipButton button;

    [SerializeField]
    bool risingup = false;

    [SerializeField]
    ParticleSystem flames;

    public bool IsRisingUp
    {
        get
        {
            return risingup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        risingup = button.IsPressed;

        if (risingup)
        {
            flames.Play();
        }
        else
        {
            flames.Stop();
        }
    }
}