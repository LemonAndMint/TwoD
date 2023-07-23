using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public string towerName;
    public int towerPrice;
    public float towerRange;
    public float towerDamage;
    public float towerReloadSec;
    public GameObject bulletPrefab;

    private int _towerInGameID;
    public int towerInGameID 
    { 
        get{ return _towerInGameID; }

        private set{ }

    }


    //#TODO tower stats olusturma yapilmali \ Corpyr.

}
