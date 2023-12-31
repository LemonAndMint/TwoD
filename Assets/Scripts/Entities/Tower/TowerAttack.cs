using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[RequireComponent(typeof(TowerStats))]
public class TowerAttack : MonoBehaviour
{
    public TowerStats towerStats;
    public GameObject towerGFX;
    private GameObject targetEnemy;
    private float timer;

    private void Start() {
        
        timer = towerStats.towerReloadSec;

        towerStats = GetComponent<TowerStats>();

    }

    private void Update() {
        
        Attack();

    }

    public void Attack(){

        if (timer > 0)
        {
        
            timer -= Time.deltaTime;
        
        }
        else{

            _shoot();
            timer = towerStats.towerReloadSec;

        }

        _rotate();

    }

    void _shoot(){

        GameObject tempEnemy;

        tempEnemy = _getNearestEnemy();

        if( _isInRange(tempEnemy) ){

            targetEnemy = tempEnemy;
            GameObject bullet = Instantiate(GetComponent<TowerStats>().bulletPrefab, new Vector3( transform.position.x, transform.position.y , 0 ),
                                                                                     Quaternion.identity);
            bullet.GetComponent<BulletStats>().SetBulletStats(towerStats.towerDamage, targetEnemy.transform);

        }

    }

    void _rotate(){

        GameObject tempEnemy;

        tempEnemy = _getNearestEnemy();
        
        if( tempEnemy != null && _isInRange(tempEnemy) ){

            targetEnemy = tempEnemy;

            _rotateTo();

        }

        _resetRotation();

    }

    private void _rotateTo(){ //https://youtu.be/1Oda2M4BoNs?t=86 / Corpyr.

        Vector3 look = towerGFX.transform.InverseTransformPoint(targetEnemy.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

        towerGFX.transform.Rotate(0 , 0, angle); 

    }

    private void _resetRotation(){ towerGFX.transform.Rotate( 0, 0, 0 ); }

    private bool _isInRange(GameObject enemy){

        if( Vector3.Distance( transform.position, enemy.transform.position) < towerStats.towerRange ){

            return true;

        }

        return false;

    }

    private GameObject _getNearestEnemy(){ 

        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        
        float distance;
        float minDistance = float.MaxValue;

        GameObject returnObject = null;

        foreach(GameObject enemy in enemies){

            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance){ minDistance = distance; returnObject = enemy;}
        
        }

        return returnObject;
    }

}
