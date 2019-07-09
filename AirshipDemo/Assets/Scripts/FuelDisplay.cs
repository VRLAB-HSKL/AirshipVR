using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDisplay : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 1f)]
    float fuelPercentage = 1f;

    //[SerializeField]
    //Oven oven;

    float maxAngle = 180;

    void Start()
    {

    }

    void Update()
    {
        //fuelPercentage = oven.FuelPercentage;
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, -(180f - maxAngle * fuelPercentage), transform.localRotation.z));
    }
}
