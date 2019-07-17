using UnityEngine;

/// <summary>
/// Stellt den Interaktionsbereich fuer einen AirshipButton zur Verfuegung.
/// </summary>
public class AirshipButtonCollider : MonoBehaviour
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
