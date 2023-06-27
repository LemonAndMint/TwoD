using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawnPointGameObject;
    public GameObject enemyPrefab;
    public List<GameObject> enemyWaypoints;

    public int enemyCount;

    private Transform enemySpawnTransform;

    void Start()
    {

        enemySpawnTransform = enemySpawnPointGameObject.transform;
        Spawn();

    }

    public void Spawn(){

        StartCoroutine(_spawn ());

    }

    IEnumerator _spawn(){

        GameObject tempEnemy;

        for(int i = 0; i < enemyCount; i++){

            tempEnemy = Instantiate(enemyPrefab, enemySpawnTransform);
            
            tempEnemy.GetComponent<EnemyMovement>().waypoints = enemyWaypoints;

            tempEnemy.transform.parent = null;

            yield return new WaitForSeconds(2f);

        }

    }

}
