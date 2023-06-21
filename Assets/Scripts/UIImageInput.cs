using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIImageInput : MonoBehaviour, IPointerClickHandler
{
    private InputManager inputManager;

    private void Awake() {
        inputManager = FindObjectOfType<InputManager>();
    }

    public void OnPointerClick(PointerEventData eventData) 
    {

        inputManager.attachSpritetoCrusor(GetComponent<Image>().sprite);
    
    }

}
