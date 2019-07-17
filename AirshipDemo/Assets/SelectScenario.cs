using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Dieses Skript beschreibt die Auswahl einer Schneekugel. Dabei kann der Benutzer mit zwei Pfeilen die jeweiligen vorherigen oder folgenden Schneekugeln anzeigen.
/// </summary>
public class SelectScenario : MonoBehaviour
{
    [SerializeField]
    LoadSceneAsync isLoading;//Wird benoetigt um herauszufinden, ob im Moment eine Szene geladen wird oder nicht.
    [SerializeField]
    List<GameObject> globes;//Enthaelt alle Schneekugel Modelle.
    [SerializeField]
    ArrowCollider LeftArrow;
    [SerializeField]
    ArrowCollider RightArrow;
    [SerializeField]
    TextMeshProUGUI label;//Das beschreibende Label welches sich unterhalb der Schneekugel Modelle befindet.

    private Vector3 startPosition;//Die urspruengliche Startposition der aktuell aktivierten Schneekugel.

    private int actualGameObject;//Index zum Speichern des aktuell sichtbaren Schneekugel Model.

    // Start is called before the first frame update
    void Start()
    {
       for(int i=0; i < globes.Capacity; i++)
        {
            if(i == 0)//Zu Beginn zeige das erste Element aus der Liste.
            {
                globes[i].SetActive(true);
                startPosition = globes[i].transform.position;
                actualGameObject = i;
                label.text = globes[i].name;
            }
            else//Alle anderen werden logischerweise deaktiviert.
            {
                globes[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoading.IsLoading)//Wird aktuell eine Szene geladen? Wenn ja lass alle anderen Schneekugeln außer der ausgewaehlten Schneekugel aus der Szene verschwinden.
        {
            for(int i=0; i < globes.Capacity; i++)
            {
                if (i == actualGameObject)
                {
                    return;
                }
                else
                {
                    globes[i].SetActive(false);
                }
            }
        }
        else //Wenn nicht ueberpruefe im nächsten Schritt ob der linke oder rechte Pfeil gedrueckt wurde.
        {
            if (RightArrow.IsPressed) //Wenn der rechte Pfeil gedrueckt wurde, dann ueberpruefe ob ein Inkrement zur noch im Indizes Bereich der Liste waere.
            {
                if(actualGameObject + 1 < globes.Capacity)
                {
                    actualGameObject++;
                    for(int i=0; i < globes.Capacity; i++)
                    {
                        if(i == actualGameObject)
                        {
                            globes[i].SetActive(true);
                            label.text = globes[i].name;

                        }
                        else
                        {
                            globes[i].transform.position = startPosition;
                            globes[i].SetActive(false);
                        }
                    }
                    startPosition = globes[actualGameObject].transform.position;
                }
            }
            else if (LeftArrow.IsPressed)//Wenn der linke Pfeil gedrueckt wurde, dann ueberpruefe ob ein Inkrement zur noch im Indizes Bereich der Liste waere.
            {
                if(actualGameObject - 1 >= 0)
                {
                    actualGameObject--;
                    for (int i = 0; i < globes.Capacity; i++)
                    {
                        if (i == actualGameObject)
                        {
                            globes[i].SetActive(true);
                            label.text = globes[i].name;

                        }
                        else
                        {
                            globes[i].transform.position = startPosition;
                            globes[i].SetActive(false);
                        }
                    }
                    startPosition = globes[actualGameObject].transform.position;
                }
            }
        }
    }
}
