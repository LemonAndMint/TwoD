using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class UIImagePrepare : MonoBehaviour
{
    public GameObject towerPrefab;

    public Text towerNameText;
    public Text towerPriceText;


    void Start()
    {

        towerNameText.text = towerPrefab.GetComponent<TowerStats>().entityName; //#FIXME
        towerPriceText.text = towerPrefab.GetComponent<TowerStats>().entityPrice.ToString();

    }
   
}
