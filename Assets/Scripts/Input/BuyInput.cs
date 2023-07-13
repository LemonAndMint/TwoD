using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyInput : MonoBehaviour, IPointerClickHandler
{
    public TowerScriptableObject towerSO; 

    private InputManager inputManager;

    private void Awake() {

        inputManager = FindObjectOfType<InputManager>();

    }

    public void OnPointerClick(PointerEventData eventData) 
    {

        inputManager.BuyInput(towerSO);
    
    }

}
