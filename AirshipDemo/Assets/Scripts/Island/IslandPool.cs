﻿using UnityEngine;

/// <summary>
/// Anpassung eines IObjectPool an die Verwendung von Isle-GameObjects.
/// </summary>
public class IslandPool : IObjectPool
{
    [SerializeField] float height = 60f;
    // Grenzwert fuer die Hoehenunterschiede der Objekte
    [SerializeField] float eventRange = 20f;
    // Entfernung, in der Objekte spawnen
    [SerializeField] Vector2 spawnRange = new Vector2(60f, 700f);
    // Abstand zwischen zwei Objekten
    [SerializeField] float tolerance = 20f;

    [SerializeField] Transform player;

    [SerializeField] bool spawnIslands = true;

    public override void InitializePool()
    {
        objects = new GameObject[poolSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(pooledObjects[Random.Range(0, pooledObjects.Length)], InitializePosition(i), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        }
    }

    void Start()
    {
        if(spawnIslands)
            InitializePool();
    }

    void Update()
    {
        if (spawnIslands)
        {
            foreach (GameObject obj in objects)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.transform.position = GetPosition();
                    obj.SetActive(true);
                }
                if (Vector3.Distance(obj.transform.position, player.position) >= spawnRange.y + 1)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    bool IsInValidRange(Vector3 position)
    {
        bool validRange = true;

        foreach (GameObject obj in objects)
        {
            if (Vector3.Distance(obj.transform.position, position) <= tolerance)
            return false;
        }


        return validRange;
    }

    Vector3 GetPosition()
    {
        Vector3 newPosition;

        do
        {
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            Vector3 v = new Vector3(Mathf.Sin(randomAngle) * spawnRange.y, Random.Range(-eventRange, eventRange), Mathf.Cos(randomAngle) * spawnRange.y);

            newPosition = v + player.position;

        } while (!IsInValidRange(newPosition));

        return newPosition;
    }

    Vector3 InitializePosition(int position)
    {
        Vector3 newPosition;

        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 v = new Vector3(Mathf.Sin(randomAngle) * Random.Range(spawnRange.x, spawnRange.y), Random.Range(-eventRange, eventRange), Mathf.Cos(randomAngle) * Random.Range(spawnRange.x, spawnRange.y));

        newPosition = v + player.position;

        return newPosition;
    }
}
