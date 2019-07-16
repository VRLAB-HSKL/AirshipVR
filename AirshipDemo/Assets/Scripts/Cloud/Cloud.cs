using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Transform cloud;

    [SerializeField] Vector2 velocityRange = new Vector2(2f, 10f);

    float velocity;

    void Start()
    {
        cloud.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

        velocity = Random.Range(velocityRange.x, velocityRange.y) * Time.deltaTime;
    }

    void Update()
    {
        transform.position += Vector3.left * velocity;
    }
}
