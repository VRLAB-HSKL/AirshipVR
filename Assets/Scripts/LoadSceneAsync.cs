using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField]
    private Image radialBar;//Radialbar zum Anzeigen des Ladefortschritts.

    //private AsyncOperation asyncLoad;//AsyncOperation zum späteren Laden der entsprechenden Szenen.


    [SerializeField]
    private ParticleSystem mTrueOrFalse;//Partikelsystem, damit der Benutzer mitbekommt, ob dieser das richtige Objekt hinzugefügt hat.

    private ParticleSystem.EmissionModule _emission;
    [SerializeField]
    private TextMeshProUGUI loadingLabel;//Label unterhalb der X-Stelle.

    private string sceneToLoad = "";//Der String, der später angibt, welche Szene nachher geladen werden soll.

    private bool isLoading = false;//Gibt an, ob im Moment eine Szene geladen wird.

    public bool IsLoading { get => isLoading; set => isLoading = value; }

    private void Awake()
    {
        _emission = mTrueOrFalse.emission;
        _emission.enabled = false;
    }

    private void Start()
    {
        radialBar.fillAmount = 0f;
    }

    /// <summary>
    /// Bei dieser Triggerabfrage, wird überprüft, ob das eintretende Objekt ein GameObject mit dem Tag "SceneGlobe" ist. 
    /// GameObjects mit dem Tag "SceneGlobe" sind zumeist eine modellierte Schneekugel mit einem Miniatur Modell zur Darstellung der auszuführenden Anwendung.
    /// Außerdem enthält der Name des GameObjects den Namen der Szene, die ausgeführt werden soll. Bitte darauf achten, dass die Szene in den Build Settings festgelegt ist.
    /// Denn nur diese speziellen GameObjects sollen im nächsten Schritt die Szene (Anhand des Namens des GameObjects) mit einer AsyncOperation gestartet werden.
    /// </summary>
    /// <param name="other">Beschreibt das in den Collider eingetretene GameObject</param>
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "SceneGlobe" && !IsLoading)//Es handelt sich bei dem GameObject um eine Schneekugel samt kleinem Modell. Außerdem wurde das Laden einer Szene noch nicht gestartet.
        {
            IsLoading = true;

            mTrueOrFalse.startColor = Color.green;
            _emission.enabled = true;
            sceneToLoad = other.gameObject.name;
            loadingLabel.text = "Loading " + other.gameObject.name + " Scenario";
            StartCoroutine(LoadScence());
        }
        else if(other.gameObject.tag == "SceneGlobe" && IsLoading)//Es handelt sich bei dem GameObject um eine Schneekugel, doch es wurde schon eine Szene geladen. Deswegen wird nichts ausgeführt!
        {
            return;
        }
        else//Es handelt sich um keine Schneekugel, dem Benutzer wird das durch ein rotes Partikelsystem und durch das Ändern des Labels dargestellt.
        {
            mTrueOrFalse.startColor = Color.red;
            _emission.enabled = true;
            loadingLabel.text = "Only a globe will work!";
            
        }
    }
    /// <summary>
    /// Der Benutzer verlässt mit seinem Controller den Collider der X-Stelle.
    /// </summary>
    /// <param name="other"> Das GameObject, dass den Collider verlässt.</param>
    private void OnTriggerExit(Collider other)
    {
        if (IsLoading)//Wenn eine Szene geladen wird wird nichts ausgeführt.
            return;
        else//Wenn nichts geladen wird, sich also auch keine Schneekugel auf der X-Stelle befindet, wird wieder der Standard Text des Labels angezeigt.
        {
            loadingLabel.text = "Place Scenario here";
            mTrueOrFalse.Stop();
        }
            
    }
   

    /// <summary>
    /// Enumerator zum Laden der zuvor in OnTriggerEnter festgelegten Szene. Hierbei wird kontinuierlich die Radial Progressbar, die sich auf dem "Table" Mesh befindet
    /// aktualisiert. Die Werte basiAsyncdabei auf dem FortsasyncOperatioSceneManager.dens.
    ///</summary>
    /// <returns></returns>    
    IEnumerator LoadScence()
    {
        SceneManager.LoadScene(this.sceneToLoad);
        yield return null;
    }
}
