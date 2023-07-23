using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMoveSpeed;

    private int _enemyInGameID;
    public int enemyInGameID 
    { 
        get{ return _enemyInGameID; }

        private set{ }

    }

    public void SetEnemyStats(float enemyHealth, float enemyMoveSpeed, int enemyInGameID){

        this.enemyHealth = enemyHealth;
        this.enemyMoveSpeed = enemyMoveSpeed;

        this._enemyInGameID = enemyInGameID;

    }    

    public void SetEnemyStats(int enemyInGameID){

        this._enemyInGameID = enemyInGameID;

    }    


}
