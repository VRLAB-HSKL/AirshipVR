using UnityEngine;

/// <summary>
/// Anpassung eines IObjectPool an die Verwendung von Fuel-GameObjects.
/// </summary>
public class FuelPool : IObjectPool
{
    // Abstand zwischen den Objekten
    [SerializeField] float spawnOffset = .2f;
    [SerializeField] float respawnRange = 10f;
    // Zeitraum, in dem Objekte spawnen koennen
    [SerializeField] float timeToSpawn = 1f;

    // Dauer eines Intervalls
    [SerializeField] int spawnIntervall = 30;

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
            // Am Ende jedes Intervalls werden timeToSpawn Sekunden lang nicht aktive Objekte gespawnt (neu positioniert und aktiviert)
            if (!obj.activeInHierarchy && Time.realtimeSinceStartup%spawnIntervall <= timeToSpawn)
            {
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                obj.transform.position = transform.position + (Vector3.forward * spawnOffset);
                obj.GetComponent<Fuel>().StartTimer = false;
                obj.SetActive(true);
            }
            if (Vector3.Distance(obj.transform.position, transform.position) >= respawnRange)
            {
                obj.GetComponent<Fuel>().StartTimer = true;
            }
        }
    }
}
