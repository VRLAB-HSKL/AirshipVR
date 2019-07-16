using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islandspawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] islands;

    [SerializeField]
    Transform player;

    [SerializeField]
    float minSpawnDistance;

    [SerializeField]
    float spawnDistance = 700f;

    [SerializeField]
    float gapSize = 100f;

    [SerializeField]
    int isles;

    [SerializeField]
    float offset;

    [SerializeField]
    float eventRange;

    // Start is called before the first frame update
    void Start()
    {
        islands = new GameObject[isles];

        for (int i = 0; i < islands.Length; i++)
        {
            islands[i] = Instantiate(islands[Random.Range(0,islands.Length)], GetPosition(), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // vector3.distance
    }

    Vector3 GetPosition()
    {
        return Vector3.zero;
    }
}
