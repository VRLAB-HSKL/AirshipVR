using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerTest2 : MonoBehaviour
{
    [SerializeField]
    Vector3 otherCollider = Vector3.zero;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float offsetAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(otherCollider != Vector3.zero)
        {
            Vector3 newUp = new Vector3(otherCollider.x - transform.position.x,
            otherCollider.y - transform.position.y, 0f).normalized;

            transform.up = newUp;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.GetType() == typeof(SphereCollider))
        {
            otherCollider = other.transform.position;

            offset = new Vector3(otherCollider.x - transform.position.x,
            otherCollider.y - transform.position.y, 0f).normalized;

            offsetAngle = Vector3.SignedAngle(transform.up, offset, Vector3.forward);
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            otherCollider = other.transform.position;
        }
    }
}
