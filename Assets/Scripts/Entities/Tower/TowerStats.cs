using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : StorableStats 
{
    public float towerRange;
    public float towerDamage;
    public float towerReloadSec;
    public GameObject bulletPrefab;

    public int towerInGameID 
    {

        get{ return _entityInGameID; }

        private set{ }

    }


    //#TODO tower stats olusturma yapilmali \ Corpyr.

}
