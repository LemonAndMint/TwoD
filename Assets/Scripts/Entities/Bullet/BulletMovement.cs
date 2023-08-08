using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletStats))]
public class BulletMovement : MonoBehaviour
{
    public BulletStats bulletStats;
    private Transform targetTransform;
    private Vector3 targetLastPosition; 

    private void Start() {
        
        bulletStats = GetComponent<BulletStats>();

        targetTransform = bulletStats.targetTransform;
        targetLastPosition = targetTransform.position;
    }

    void FixedUpdate()
    {
        
        _move();

    }

    private void _move(){

        if(targetTransform != null){
        
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, Time.deltaTime * bulletStats.bulletSpeed);
            targetLastPosition = targetTransform.position;
        
        }
        else{

            transform.position = Vector3.MoveTowards(transform.position, targetLastPosition, Time.deltaTime * bulletStats.bulletSpeed);
            
            if( Vector3.Distance(transform.position, targetLastPosition) < 0.05f ){

                bulletStats.DestroyBullet();
            }
        }

    }
}
