using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObjectPool : MonoBehaviour
{
    public GameObject[] pooledObjects;

    public int poolSize = 5;

    public bool isActive = false;

    public GameObject[] objects;

    public virtual void InitializePool()
    {
        objects = new GameObject[poolSize];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = Instantiate(pooledObjects[Random.Range(0, pooledObjects.Length - 1)], Vector3.zero, Quaternion.Euler(0f, 0f, 0f));
            objects[i].SetActive(isActive);
        }
    }
}
