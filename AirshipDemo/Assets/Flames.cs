using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    [SerializeField]
    AirshipButtonCollider button_up;

    [SerializeField]
    bool risingup = false;
    private ParticleSystem flames;
    public bool IsRisingUp
    {
        get
        {
            return risingup;
        }
    }
    private void Start()
    {
        flames = this.gameObject.GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        risingup = button_up.IsPressed;

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