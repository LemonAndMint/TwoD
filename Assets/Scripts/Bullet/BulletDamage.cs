using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageValue;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Enemy" && other.GetComponent<EnemyHealth>() != null){

            other.GetComponent<EnemyHealth>().TakeDamage(damageValue); //#TODO Mermi atesle

        }

    }

}
