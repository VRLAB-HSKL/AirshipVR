using UnityEngine;

/// <summary>
/// Bewegt die Luke des Airships.
/// </summary>
public class Ventilation : MonoBehaviour
{
    [SerializeField] AirshipButton button;

    [SerializeField] Transform hatch;

    bool fall = false;

    [SerializeField] Vector2 angleRange = new Vector2(0f, 90f);

    public bool IsFalling
    {
        get
        {
            return fall;
        }
    }

    void Update()
    {
        fall = button.IsPressed;

        if (fall)
        {
            hatch.transform.localRotation = Quaternion.RotateTowards(hatch.transform.localRotation, Quaternion.Euler(0f, 0f, angleRange.y), 10f);
        }
        else
        {
            hatch.transform.localRotation = Quaternion.RotateTowards(hatch.transform.localRotation, Quaternion.Euler(0f, 0f, angleRange.x), 10f);
        }
    }
}
