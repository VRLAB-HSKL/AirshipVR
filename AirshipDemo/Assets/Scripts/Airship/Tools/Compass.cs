using UnityEngine;

/// <summary>
/// Zeigt auf den Mittelpunkt der Welt. 
/// </summary>
public class Compass : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}
