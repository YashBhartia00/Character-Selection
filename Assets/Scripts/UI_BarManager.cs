using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BarManager : MonoBehaviour
{
    public float currentValue=100, MaxValue=100;
    public RectTransform current,container; 
    Vector3 initalposition,initalpositionC;

    void Start()
    {
        current =gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        container = gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        initalposition=current.localPosition;
        initalpositionC=container.localPosition;

        transform.GetChild(2).GetComponent<Text>().text=gameObject.name;
    }

    void Update()
    {
        if(currentValue>MaxValue) {currentValue=MaxValue;}
        if(currentValue<0) {currentValue=0;}

        container.sizeDelta = new Vector2(MaxValue,container.sizeDelta.y);
        container.localPosition = initalpositionC+new Vector3(MaxValue-100,0,0)/2;
        current.sizeDelta = new Vector2(currentValue,current.sizeDelta.y);
        current.localPosition = initalposition+new Vector3(currentValue-1,0,0)/2;
    }
}
