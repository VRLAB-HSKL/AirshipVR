using UnityEngine;

/// <summary>
/// Uebertraegt den Hoehenwert des Airship auf einen Zeiger.
/// </summary>
public class Altimeter : MonoBehaviour
{
    [SerializeField] Transform pointer;
    [SerializeField] Transform airship;

    [SerializeField]
    [Range(.001f, 20f)] float eventRange = 20f;

    float actualHeight;

    [SerializeField] float scaleRange = 0.13f;

    float percent;

    [SerializeField] float offset = 50f;

    void Update()
    {
        actualHeight = airship.transform.position.y;

        percent = (actualHeight - offset) / eventRange;

        pointer.transform.localPosition = new Vector3(pointer.transform.localPosition.x, scaleRange * percent, pointer.transform.localPosition.z);
    }
}
