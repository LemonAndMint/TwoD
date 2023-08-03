using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDieEvent : UnityEvent<EnemyStats>{ }

[RequireComponent(typeof(EnemyStats))]
public class EnemyHealth : MonoBehaviour
{
    public OnDieEvent onDie;
    public EnemyStats enemyStats;

    private void Awake() {
        
        enemyStats = GetComponent<EnemyStats>();
        onDie = new OnDieEvent();

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

        onDie.Invoke(GetComponent<EnemyStats>());
        Destroy(this.gameObject);

    }

    private void OnDestroy() {
        
        onDie.Invoke(GetComponent<EnemyStats>());

    }

}
