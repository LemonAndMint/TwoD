using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerInfoPanel : MonoBehaviour, IPointerDownHandler
{
    public GameObject Canvas;
    public GameObject SelectionSquare;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(Canvas.activeSelf == true){ Canvas.SetActive(false); SelectionSquare.SetActive(false); }
        else { Canvas.SetActive(true); SelectionSquare.SetActive(true); }
    }

}
