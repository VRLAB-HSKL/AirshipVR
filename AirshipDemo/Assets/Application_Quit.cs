using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application_Quit : MonoBehaviour
{
    /// <summary>
    /// Möchte der Benutzer die Anwendung verlassen, so muss er in der "Start" Szene nur durch den Notausgang gehen. In der "ShipDemo" Szene 
    /// muss er die Türklinge mit dem Controller berühren.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
