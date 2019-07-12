using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerTest : MonoBehaviour
{

    [SerializeField]
    Vector3 otherCollider;

    [SerializeField]
    float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = otherCollider - transform.position;

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetType() == typeof(SphereCollider))
        {
            otherCollider = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}

