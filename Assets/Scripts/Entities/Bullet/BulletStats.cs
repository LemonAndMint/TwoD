using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public float damageValue;
    public float bulletSpeed; //Inspectorden ayarlanmali \ Corpyr.

    /*
     * Property init alternatif cozum. Init setter unity'nin desteklemedigi bir .net 5 ozelligi. 
     * Bunun icin sinif icerisinde sadece Instatintiate metodunda deger atanir. \ Corpyr. 
     */

    private int _targetEnemyID; 
    public int targetEnemyID{ 

        get { 

            return _targetEnemyID;

        }
        
        private set{} 
        
    }
    
    private Transform _targetTransform;
    public Transform targetTransform { 
        
        get { 

            return _targetTransform;

        }
        
        private set{} 
        
    }

    public void SetBulletStats(float damageValue, Transform targetTransform){

        this.damageValue = damageValue;
        this._targetTransform = targetTransform;

        _targetEnemyID = targetTransform.GetComponent<EnemyStats>().enemyInGameID; 

    }

    public void DestroyBullet(){ 

        Destroy(this.gameObject);

    }
}
