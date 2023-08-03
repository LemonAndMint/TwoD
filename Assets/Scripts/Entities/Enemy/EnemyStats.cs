using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : StorableStats 
{
    public float enemyHealth;
    public float enemyMoveSpeed;

    /*public int enemyInGameID 
    { 
        get{ return GetInGameID(); }

        private set{ }

    }*/

    public void SetEnemyStats(float enemyHealth, float enemyMoveSpeed){

        this.enemyHealth = enemyHealth;
        this.enemyMoveSpeed = enemyMoveSpeed;

    }    


}
