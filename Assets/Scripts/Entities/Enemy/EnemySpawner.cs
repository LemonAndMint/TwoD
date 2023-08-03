using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemySpawnPointGameObject;
    public List<GameObject> enemyWaypoints;

    public int enemySpawnCount;
    public float enemySpawnTime;

    private Transform enemySpawnTransform;

    void Start()
    {

        enemySpawnTransform = enemySpawnPointGameObject.transform;
        _spawn();

    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.S) == true){

            SpawnEnemy();

        }

    }

    private void _spawn(){

        StartCoroutine(_IEspawn());

    }

    public void SpawnEnemy(){ //# Isim degistirmeli miyiz? \ Corpyr.

        GameObject tempEnemy;

        tempEnemy = Instantiate(enemyPrefab, enemySpawnTransform);
        tempEnemy.transform.parent = null;

        EntityStorage.Instance.AddToStorage<EnemyStats>(tempEnemy.GetComponent<EnemyStats>());
        tempEnemy.GetComponent<EnemyMovement>().waypoints = enemyWaypoints; //#FIXME waypoint atama farkli yerde olabilir. 

    }

    IEnumerator _IEspawn(){


        for(int i = 0; i < enemySpawnCount - 1; i++){

            SpawnEnemy();

            yield return new WaitForSeconds(enemySpawnTime);

        }

    }

}
