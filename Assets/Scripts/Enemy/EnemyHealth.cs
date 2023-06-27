using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour
{
    public EnemyStats enemyStats;

    private void Start() {
        
        enemyStats = GetComponent<EnemyStats>();

    }

    public void TakeDamage(float damageValue){

        enemyStats.enemyHealth -= damageValue;
        _checkHealth();

    }

    private void _checkHealth(){

        if(enemyStats.enemyHealth <= 0f){

            _die();

        }

    }

    private void _die(){

        Destroy(this.gameObject);

    }

}
