using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectScenario : MonoBehaviour
{
    [SerializeField]
    LoadSceneAsync isLoading;
    [SerializeField]
    List<GameObject> globes;
    [SerializeField]
    ArrowCollider LeftArrow;
    [SerializeField]
    ArrowCollider RightArrow;
    [SerializeField]
    TextMeshProUGUI label;
    private Vector3 startPosition;
    private int actualGameObject;
    // Start is called before the first frame update
    void Start()
    {
       for(int i=0; i < globes.Capacity; i++)
        {
            if(i == 0)
            {
                globes[i].SetActive(true);
                startPosition = globes[i].transform.position;
                actualGameObject = i;
                label.text = globes[i].name;
            }
            else
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
        else
        {
            if (RightArrow.IsPressed)
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
            else if (LeftArrow.IsPressed)
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
