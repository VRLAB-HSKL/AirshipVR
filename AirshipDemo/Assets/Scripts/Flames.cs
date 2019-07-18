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

        if (risingup && !OvenScript.NoFuel)
        {
            flames.Play();
        }
        else if (risingup && OvenScript.NoFuel)
        {
            flames.Stop();
        }else
        {
            flames.Stop();
        }
    }
}