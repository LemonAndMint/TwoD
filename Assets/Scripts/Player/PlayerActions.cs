using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public MapManager mapManager;
    public InputManager inputManager;
    public Currency currency;

    public void BuyTower(TowerData towerSO){

        GameObject towerGO = mapManager.placeTower(towerSO.TowerPrefab);
        EntityStorage.Instance.AddToStorage<TowerStats>(towerGO.GetComponent<TowerStats>());

        if(towerGO != null){ currency.loseGold(towerGO.GetComponent<TowerStats>().entityPrice); } //#FIXME \ Corpyr.
        
        inputManager.SetSpriteNull();

    }
    public void SellTower(int towerInGameID){

        EntityStorage.Instance.RemoveFromStorage<TowerStats>(towerInGameID);

    }
    public void UpgradeTower(){}
    public void PlaceTower(){}
    public void BuyCancelTower(){}

    //Canavarlar hakkinda da aksiyonlar olacak \ Corpyr.




}
