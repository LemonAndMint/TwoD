using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public float enemyHealth;
    public float enemyMoveSpeed;

    public int enemyInGameID 
    { 
        get{ return _entityInGameID; }

        private set{ }

    }

    public void SetEnemyStats(float enemyHealth, float enemyMoveSpeed, int enemyInGameID){

        this.enemyHealth = enemyHealth;
        this.enemyMoveSpeed = enemyMoveSpeed;

        this._entityInGameID = enemyInGameID;

    }    

    public void SetEnemyStats(int enemyInGameID){

        this._entityInGameID = enemyInGameID;

    }    


}
