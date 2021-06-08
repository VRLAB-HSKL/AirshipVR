using UnityEngine;

/// <summary>
/// Interpoliert zwischen zwei Farben eines Materials.
/// </summary>
public class ColorLerper : MonoBehaviour
{
    [SerializeField] SteeringWheel steeringWheel;

    [SerializeField] Color minColor;
    [SerializeField] Color maxColor;

    [SerializeField]
    [Range(0f, 1f)]
    float intensity;

    new Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        GetIntensity();

        intensity = Mathf.Clamp(intensity, 0f, 1f);
        renderer.material.color = Color.Lerp(minColor, maxColor, intensity);
    }

    void GetIntensity()
    {
        float steeringValue = Mathf.Abs(steeringWheel.GetSteeringValue);
        intensity = steeringValue / 2f;
    }
}
