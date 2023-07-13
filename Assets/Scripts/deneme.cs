using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class deneme : MonoBehaviour,  IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) 
    {

        Debug.Log("it works");
    
    }
}
