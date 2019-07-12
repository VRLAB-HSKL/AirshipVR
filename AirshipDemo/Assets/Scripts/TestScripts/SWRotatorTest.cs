using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWRotatorTest : MonoBehaviour
{
    [SerializeField]
    bool controlerSticked = false;

    float angleStickyOffset;
    float wheelLastSpeed;
    float inertia = 0.95f;
    float maxRoatation = 720;
    float wheelhapticFrequency = 360 / 12;

    [SerializeField]
    Transform wheelBase;

    [SerializeField]
    Vector3 relativePosition;

    List<float> lastValues = new List<float>(); 
    List<float> Diffs = new List<float>(); 
    List<float> formulaDiffs = new List<float>();
    List<float> increment = new List<float>(); 

    void Start()
    {
        CreateArrays(5); // CALLING FUNCTION WHICH CREATES ARRAYS
        angleStickyOffset = 0f;
        controlerSticked = false;
        wheelLastSpeed = 0;
    }

    void Update()
    {
        
    }

    #region Methodes

    void CreateArrays(int firstPparam) // FUNCTION WHICH CREATING ARRAYS
    {
        for (int i = 0; i < firstPparam; i++) // FOR LOOP WITH PARAM
        {
            lastValues.Add(0);  // LAST VALUES ARRAY
        }


        for (int i = 0; i < firstPparam - 1; i++) // FOR LOOP WITH PARAM -1
        {
            Diffs.Add(0); // ARRAY TO STORE DIFFERECE BETWEEN NEXT AND PREV
            formulaDiffs.Add(0); // ARRAY TO STORE FORMULATED DIFFS
            increment.Add(0); //  ARRAY TO STORE INCREMENT FOR EACH WHEEL SPIN

        }
    }

    #endregion

}
