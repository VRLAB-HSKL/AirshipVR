﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altimeter : MonoBehaviour
{
    [SerializeField] Transform pointer;

    [SerializeField]
    [Range(.001f, 20f)]
    float eventRange = 20f;

    [SerializeField]
    float actualHeight;

    [SerializeField]
    float scaleRange = 0.13f;

    [SerializeField]
    [Range(-1f, 1f)]
    float percent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        actualHeight = Mathf.Clamp(transform.position.y, -eventRange, eventRange);

        percent = actualHeight / eventRange;

        pointer.transform.localPosition = new Vector3(pointer.transform.localPosition.x, scaleRange * percent, pointer.transform.localPosition.z);
    }
}
