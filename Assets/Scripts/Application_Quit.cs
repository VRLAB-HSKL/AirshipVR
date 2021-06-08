using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HTC.UnityPlugin.Vive;
public class Application_Quit : MonoBehaviour
{
   
    [SerializeField]
    private bool inStartScene;//Gibt an, ob sich der Benutzer gerade in der Start Szene befindet. TRUE = Ja, er befindet sich in der "Start" Szene. FALSE = Nein, er befindet sich in der "Main" Szene.
    private AsyncOperation asyncLoad;//AsyncOperation Objekt zum späteren asynchronen Laden der "Start" Szene.

    /// <summary>
    /// Möchte der Benutzer die Anwendung verlassen, so muss er in der "Start" Szene nur durch den Notausgang gehen. In der "Main" Szene 
    /// muss er die Türklinge mit dem Controller berühren.
    /// </summary>
    /// <param name="other"> Beschreibt das in den Collider eingetretene GameObject</param>
    private void OnTriggerStay(Collider other)
    {
        if (inStartScene)//Der Benutzer befindet sich in der "Start" Szene und geht gerade durch den Türrahmen des Notausgangs.
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
        else//Der Benutzer befindet sich gerade in der "Main" Szene und möchte wieder zurück zur "Start" Anwendung.
        {
            
            if (other.GetType() == typeof(SphereCollider))//Handelt es sich um den SphereCollider eines Vive Controllers?
            {
                
                if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger) || ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Trigger))//Wenn ja wurde ein Trigger von einem der beiden Controller getätigt.
                {
                    StartCoroutine(LoadAsyncScene());
                }
                else//Falls es zu einem unvorhergesehenen Fehler kommen sollte und ein Objekt mit einem Scene Collider durch den Box Collider der Tür fallen sollte, soll nichts passieren.
                {
                    return;
                }
            }
        }
    }
       
    IEnumerator LoadAsyncScene()//Lädt Asynchron die Szene "Start"
    {
        yield return asyncLoad = SceneManager.LoadSceneAsync("Start");
    }
}
