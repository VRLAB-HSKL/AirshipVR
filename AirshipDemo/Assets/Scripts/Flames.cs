using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ueberprueft ob der Button zum Aufsteigen des Luftschiffs gedrueckt wird, wenn ja aktiviere das Partikelsystem, welches am Brenner des Luftschiffs angebracht wurde.
/// </summary>
public class Flames : MonoBehaviour
{
    [SerializeField]
    AirshipButtonCollider button_up;
    [SerializeField]
    Oven OvenScript;
    [SerializeField]
    bool risingup = false;
    private ParticleSystem flames;
    private ParticleSystem.EmissionModule _emission;
    public bool IsRisingUp
    {
        get
        {
            return risingup;
        }
    }
    private void Awake()
    {

        flames = this.gameObject.GetComponent<ParticleSystem>();
        _emission = flames.emission;
        _emission.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        risingup = button_up.IsPressed;

        if (risingup && !OvenScript.NoFuel)
        {
            _emission.enabled = true;
        }
        else if (risingup && OvenScript.NoFuel)
        {
            _emission.enabled = false;
        }
        else
        {
            _emission.enabled = false;
        }
    }
}