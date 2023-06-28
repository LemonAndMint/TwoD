using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UICurrency : MonoBehaviour
{
    public Currency currency;
    public Text currencyText;

    private void Start() {
        
        currency = GetComponent<Currency>();

    }
    
    private void Update() {
        
        currencyText.text = currency.gold.ToString();

    }

}
