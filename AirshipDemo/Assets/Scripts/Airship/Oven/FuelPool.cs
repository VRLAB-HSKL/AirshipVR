using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPool : IObjectPool
{
    [SerializeField]
    float spawnOffset = .2f;

    [SerializeField]
    float respawnRange = 10f;

    [SerializeField]
    int spawnIntervall = 10;

    [SerializeField]
    float timeToSpawn = 1f;

    void Start()
    {
        InitializePool();
    }

    public override void InitializePool()
    {
        objects = new GameObject[poolSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(pooledObjects[Random.Range(0, pooledObjects.Length)], transform);
            objects[i].transform.position = transform.position + (Vector3.up * i * spawnOffset);
        }
    }

    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy && Time.realtimeSinceStartup%spawnIntervall <= timeToSpawn)
            {
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                obj.transform.position = transform.position + (Vector3.forward * spawnOffset);
                obj.SetActive(true);
            }
            if (Vector3.Distance(obj.transform.position, transform.position) >= respawnRange)
            {
                obj.SetActive(false);
            }
        }
    }
}
