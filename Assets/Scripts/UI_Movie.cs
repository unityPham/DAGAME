using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UI_Movie : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Vector3 positionFrom, positionStamp, localScaleStamp;
    public bool scaleEffect, isButton;
    public float scaleSize,buttonUpDownSize;
    void Start()
    {
        buttonUpDownSize = 1;
        localScaleStamp = transform.localScale;
        positionStamp = transform.localPosition;
        transform.localPosition = positionFrom;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleEffect)
        {
            scaleSize += GameManager.THIS.gamePlayDeltaFrame*0.5f;
            scaleSize = scaleSize % 20;
            float scaleObj = (Math.Abs(scaleSize - 10))*0.005f;
            transform.localScale = new Vector2(localScaleStamp.x * (1 + scaleObj), localScaleStamp.y * (1 / (1 + scaleObj)))*buttonUpDownSize;
        }
        transform.localPosition += (positionStamp - transform.localPosition) * 0.1f;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(isButton) buttonUpDownSize = 0.9f;
    }
    public void OnPointerUp(PointerEventData data)
    {
        if(isButton) buttonUpDownSize = 1;
    }

}
