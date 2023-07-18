using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public MapManager mapManager;
    public InputManager inputManager;
    public Currency currency;

    public void BuyTower(TowerData towerSO){


        bool isBought = mapManager.placeTower(towerSO.TowerPrefab);

        if(isBought == true){ currency.loseGold(towerSO.TowerPrefab.GetComponent<TowerStats>().towerPrice); }
        
        inputManager.SetSpriteNull();

    }
    public void SellTower(){}
    public void UpgradeTower(){}
    public void PlaceTower(){}
    public void BuyCancelTower(){}

    //Canavarlar hakkinda da aksiyonlar olacak \ Corpyr.




}
