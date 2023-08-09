using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public MapManager mapManager;
    public InputManager inputManager;
    public Storage<TowerStats> towerStorage;

    public Currency currency;

    private void Start() {
        
        inputManager = InputManager.Instance;
        towerStorage = Storage<TowerStats>.Instance;

    }

    public void BuyTower(TowerData towerSO){

        GameObject towerGO = mapManager.placeTower(towerSO.TowerPrefab);

        towerGO.GetComponent<TowerEventHandler>().onSell.AddListener(SellTower);
        towerStorage.AddToStorage(towerGO.GetComponent<TowerStats>());
        currency.loseGold(towerGO.GetComponent<TowerStats>().entityPrice); 
        
        inputManager.SetSpriteNull(); //#FIXME \ Corpyr.

    }
    public void SellTower(int towerInGameID){

        TowerStats towerStats = towerStorage.GetItem(towerInGameID);
        GameObject towerGO = towerStats.gameObject;
        
        currency.gainGold(towerStats.entityPrice);
        towerStorage.RemoveFromStorage(towerInGameID);
        Destroy(towerGO);

    }
    public void UpgradeTower(){}
    public void PlaceTower(){}
    public void BuyCancelTower(){}

    //Canavarlar hakkinda da aksiyonlar olacak \ Corpyr.




}
