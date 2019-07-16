using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField]
    AirshipButton button;

    [SerializeField]
    float maxFuel = 2000;

    [SerializeField]
    float actualFuel = 2000;

    [SerializeField]
    float fuelPercentage;

    public float FuelPercentage
    {
        get
        {
            return fuelPercentage;
        }
    }

    [SerializeField]
    bool lift = false;

    public bool IsLifting
    {
        get
        {
            return lift;
        }
    }

    [SerializeField]
    float fuelValue = 500;

    [SerializeField]
    [Range(20f, 100f)]
    float fuelBurnDecay = 20f;

    [SerializeField]
    [Range(0f, 2f)]
    float fuelDecay = 2f;

    [SerializeField]
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
