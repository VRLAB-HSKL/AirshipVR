using UnityEngine;

/// <summary>
/// Deaktiviert das dazugehoerige GameObject. Wird in der FuelPool-Klasse verwendet.
/// </summary>
public class Fuel : MonoBehaviour
{
    [SerializeField]
    float respawnTime = 20f;

    bool startTimer = false;

    public bool StartTimer
    {
        get
        {
            return startTimer;
        }
        set
        {
            startTimer = value;
        }
    }

    void Update()
    {
        if(startTimer)
            Timer();
    }

    void Timer()
    {
        respawnTime -= Time.deltaTime;

        if (respawnTime < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
