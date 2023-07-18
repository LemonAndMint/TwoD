using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletStats))]
public class BulletDamage : MonoBehaviour
{

    public BulletStats bulletStats;

    private void Start() {
        
        bulletStats = GetComponent<BulletStats>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Enemy" && other.GetComponent<EnemyStats>() != null && 
                                   other.GetComponent<EnemyHealth>() != null && 
                                   other.GetComponent<EnemyStats>().enemyInGameID == GetComponent<BulletStats>().targetEnemyID){

            other.GetComponent<EnemyHealth>().TakeDamage(bulletStats.damageValue);

            bulletStats.DestroyBullet();

        }

    }

}
