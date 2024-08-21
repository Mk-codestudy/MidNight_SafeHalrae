using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AutoTextSize : MonoBehaviour
{
    public float titleHeight = 120;
    public RectTransform logText;

    RectTransform rect;
    //Rect originSize;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        //if(rect != null )
        //{
        //    originSize = rect.rect;
        //}
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(logText.rect.width, logText.rect.height + titleHeight);
    }
}
