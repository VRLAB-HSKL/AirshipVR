using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPooler : MonoBehaviour
{
    [SerializeField]
    GameObject gameObject;

    [SerializeField]
    int poolerSize = 5;

    [SerializeField]
    float distance = .2f;

    [SerializeField]
    GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[poolerSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(gameObject, transform.position + (Vector3.forward * i * distance), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = transform.position;
                obj.SetActive(true);
            }
        }
    }
}
