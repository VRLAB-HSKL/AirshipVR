using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPool : IObjectPool
{
    [SerializeField] float height = 60f;
    [SerializeField] float eventRange = 40f;
    [SerializeField] float spawnRange = 700f;

    [SerializeField] Transform player;

    public override void InitializePool()
    {
        objects = new GameObject[poolSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(pooledObjects[Random.Range(0, pooledObjects.Length)], InitializePosition(), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    void Start()
    {
        InitializePool();
    }

    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = GetPosition();
                obj.SetActive(true);
            }
            if (Vector3.Distance(obj.transform.position, player.position) >= spawnRange + 1)
            {
                obj.SetActive(false);
            }
        }
    }

    Vector3 GetPosition()
    {
        float randomAngle = Random.Range(0f, 180f) * Mathf.Deg2Rad;

        Vector3 v = new Vector3(Mathf.Sin(randomAngle) * spawnRange, Random.Range(-eventRange, eventRange), Mathf.Cos(randomAngle) * spawnRange);

        return v + player.position;
    }

    Vector3 InitializePosition()
    {
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 v = new Vector3(Mathf.Sin(randomAngle) * Random.Range(10f, spawnRange), Random.Range(-eventRange, eventRange), Mathf.Cos(randomAngle) * Random.Range(10f, spawnRange));

        return v + player.position;
    }
}
