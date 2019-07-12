using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField]
    private StartScenario radialBar;

    private AsyncOperation asyncLoad;


    [SerializeField]
    private ParticleSystem mTrueOrFalse;
    
    [SerializeField]
    private TextMeshProUGUI loadingLabel;

    private string sceneToLoad = "";

    private bool isLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        radialBar.OnChange(this.onRadialBarChange);
        radialBar.onDone(this.OnRadialBarDone);
        
    }
    /// <summary>
    /// Bei dieser Triggerabfrage, wird überprüft, ob das eintretende Objekt ein GameObject mit dem Tag "SceneGlobe" ist. 
    /// GameObjects mit dem Tag "SceneGlobe" sind zumeist eine modellierte Schneekugel mit einem Miniatur Modell zur Darstellung der auszuführenden Anwendung.
    /// Außerdem enthält der Name des GameObjects den Namen der Szene, die ausgeführt werden soll. Bitte darauf achten, dass die Szene in den Build Settings festgelegt ist.
    /// Denn nur diese speziellen GameObjects sollen im nächsten Schritt die Szene (Anhand des Namens des GameObjects) mit einer AsyncOperation gestartet werden.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "SceneGlobe" && !isLoading)
        {
            isLoading = true;
            mTrueOrFalse.startColor = Color.green;
            mTrueOrFalse.Play();
            sceneToLoad = other.gameObject.name;
            loadingLabel.text = "Loading " + other.gameObject.name + " Scenario";
            StartCoroutine(LoadAsyncScence());
        }
        else if(other.gameObject.tag == "SceneGlobe" && isLoading)
        {

        }
        else
        {
            mTrueOrFalse.startColor = Color.red;
            mTrueOrFalse.Play();
            loadingLabel.text = "Only a globe will work!";
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isLoading)
            return;
        else
        {
            loadingLabel.text = "Place Scenario here";
            mTrueOrFalse.Stop();
        }
            
    }
    void onRadialBarChange(float value)
    {
        //print("Value: " + value);
    }
    void OnRadialBarDone()
    {
        //print("Done");
    }

    /// <summary>
    /// Enumerator zum Laden der zuvor in OnTriggerEnter festgelegten Szene. Hierbei wird kontinuierlich die Radial Progressbar, die sich auf dem "Table" Mesh befindet
    /// aktualisiert. Die Werte basieren dabei auf dem Fortschritt des asynchronen Ladens.
    /// </summary>
    /// <returns></returns>    
    IEnumerator LoadAsyncScence()
    {
        asyncLoad = SceneManager.LoadSceneAsync(this.sceneToLoad);
      

        while (!asyncLoad.isDone)
        {
            radialBar.SetValue(Mathf.Clamp01(asyncLoad.progress / 0.9f));
            yield return null;
        }
    }
}
