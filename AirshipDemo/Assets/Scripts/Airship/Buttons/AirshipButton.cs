using UnityEngine;

/// <summary>
/// Stellt die Funktionalitaet eines Buttons zur Verfuefung
/// </summary>
public class AirshipButton : MonoBehaviour
{
    // Beweglicher Teil eines Buttons
    [SerializeField] Transform button;
    // Interaktionsbereich
    [SerializeField] AirshipButtonCollider collider;
    [SerializeField] ParticleSystem flames;

    Vector3 upPosition;
    Vector3 downPosition;

    float range = 0.04f;

    bool pressed = false;

    public bool IsPressed
    {
        get
        {
            return pressed;
        }
    }

    void Start()
    {
        upPosition = button.transform.localPosition;
        downPosition = button.transform.localPosition - Vector3.up * range;
    }

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
