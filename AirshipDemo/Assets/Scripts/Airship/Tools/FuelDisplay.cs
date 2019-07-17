using UnityEngine;

/// <summary>
/// Gibt den Tankinhalt an. Ofen fungiert als Tank.
/// </summary>
public class FuelDisplay : MonoBehaviour
{
    [SerializeField] Oven oven;

    float fuelPercentage = 1f;

    float maxAngle = 180;

    void Start()
    {

    }

    void Update()
    {
        fuelPercentage = oven.FuelPercentage;
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, -(180f - maxAngle * fuelPercentage), transform.localRotation.z));
    }
}
