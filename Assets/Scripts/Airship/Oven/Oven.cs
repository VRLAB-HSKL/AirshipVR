using UnityEngine;

/// <summary>
/// Stellt den Tank fuer das Airship zur Verfuegung.
/// </summary>
public class Oven : MonoBehaviour
{
    [SerializeField] AirshipButton button;

    [SerializeField] float maxFuel = 2000f;
    [SerializeField] float fuelValue = 500f;
    [SerializeField]
    [Range(20f, 100f)] float fuelBurnDecay = 20f;
    [SerializeField]
    [Range(0f, 2f)] float fuelDecay = 2f;

    float actualFuel = 1500f;

    float fuelPercentage;

    public float FuelPercentage
    {
        get
        {
            return fuelPercentage;
        }
    }

    bool lift = false;

    public bool IsLifting
    {
        get
        {
            return lift;
        }
    }

    bool noFuel = false;

    public bool NoFuel
    {
        get
        {
            return noFuel;
        }
    }

    void Start()
    {
        fuelPercentage = 1f;
    }

    void Update()
    {
        if (!noFuel)
        {
            lift = button.IsPressed;
        }
        
        fuelPercentage = actualFuel / maxFuel;

        if (lift && !noFuel)
        {
            UseBurner();
        }
        else
        {
            actualFuel -= fuelDecay * Time.deltaTime;
            actualFuel = Mathf.Clamp(actualFuel, 0f, maxFuel);
            lift = false;
        }


    }

    void AddFuel()
    {
        actualFuel += fuelValue; 
        actualFuel = Mathf.Clamp(actualFuel, 0f, maxFuel);

        if (actualFuel > fuelBurnDecay)
        {
            noFuel = false;
        }
    }

    void UseBurner()
    {
        if (!noFuel)
        {
            actualFuel = actualFuel - fuelBurnDecay * Time.deltaTime;
            actualFuel = Mathf.Clamp(actualFuel, 0f, maxFuel);
        }

        if(actualFuel <= fuelBurnDecay)
        {
            noFuel = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            AddFuel();
            other.gameObject.SetActive(false);
        }
    }
}
