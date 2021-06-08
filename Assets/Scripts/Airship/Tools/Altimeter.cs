using UnityEngine;

/// <summary>
/// Uebertraegt den Hoehenwert des Airship auf einen Zeiger.
/// </summary>
public class Altimeter : MonoBehaviour
{
    [SerializeField] Transform pointer;
    [SerializeField] Transform airship;

    [SerializeField] float maxHeight = 80f;

    float actualHeight;

    [SerializeField] float scaleRange = 0.26f;

    float percent;

    void Update()
    {
        actualHeight = airship.transform.position.y;

        percent = actualHeight / maxHeight;

        pointer.transform.localPosition = new Vector3(pointer.transform.localPosition.x, (scaleRange * percent) - (scaleRange / 2), pointer.transform.localPosition.z);
    }
}
