using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyInput : MonoBehaviour, IPointerClickHandler
{
    public TowerData towerSO; 

    private InputManager inputManager;

    private void Awake() {

        inputManager = InputManager.Instance;

    }

    public void OnPointerClick(PointerEventData eventData) 
    {

        inputManager.BuyInput(towerSO);
    
    }

}
