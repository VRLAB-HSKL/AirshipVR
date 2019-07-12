using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class SWControler : MonoBehaviour
{
    [SerializeField]
    Transform right;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ViveInput.GetPressDownEx(HandRole.RightHand, ControllerButton.Trigger))
        {
            Debug.Log("möp");

            right.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
