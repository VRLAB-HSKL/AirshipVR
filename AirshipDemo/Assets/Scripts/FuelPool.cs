using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPool : MonoBehaviour
{
    [SerializeField]
    GameObject gameObject;

    [SerializeField]
    int poolSize = 5;

    [SerializeField]
    float distance = .2f;

    [SerializeField]
    GameObject[] objects;

    [SerializeField]
    float respawnRange = 10f;

    [SerializeField]
    int spawnIntervall = 10;

    [SerializeField]
    float timeToRespawn = 1f;

    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[poolSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(gameObject, transform.position + (Vector3.up * i * distance), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy && Time.realtimeSinceStartup%spawnIntervall <= timeToRespawn)
            {
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                obj.transform.position = transform.position + (Vector3.forward * distance);
                obj.SetActive(true);
            }
            if (Vector3.Distance(obj.transform.position, transform.position) >= respawnRange)
            {
                obj.SetActive(false);
            }
        }
    }
}
