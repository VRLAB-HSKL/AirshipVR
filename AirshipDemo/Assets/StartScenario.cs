using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScenario : MonoBehaviour
{
    [SerializeField]
    private Image Fillimage;

    private float value = 0f;
    private bool isDone = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Fillimage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone)
        {
            if (this.OnDoneEvent != null)
                this.OnDoneEvent();
            this.OnDoneEvent = null;
            this.OnChangeEvent = null;
            return;
        }

        if (this.OnChangeEvent != null)
            this.OnChangeEvent((int)(value * 100));

        Fillimage.fillAmount = value;
        isDone = value >= 1 ? true : false;
    }
    public void SetValue(float value)
    {
        this.value = value;
    }
    public float GetValue()
    {
        return value;
    }
    #region Events

    public void OnChange(ValueChange method)
    {
        this.OnChangeEvent += method;
    }
    public void onDone(ProgressDone method)
    {
        this.OnDoneEvent += method;
    }
    public delegate void ValueChange(float value);
    private event ValueChange OnChangeEvent;

    public delegate void ProgressDone();
    private event ProgressDone OnDoneEvent;
    #endregion
}
