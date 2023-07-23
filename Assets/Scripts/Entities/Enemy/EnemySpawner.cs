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
        Spawn();

    }

    public void Spawn(){

        StartCoroutine(_spawn());

    }

    IEnumerator _spawn(){

        GameObject tempEnemy;

        for(int i = 0; i < enemySpawnCount - 1; i++){

            tempEnemy = Instantiate(enemyPrefab, enemySpawnTransform);
            tempEnemy.transform.parent = null;

            tempEnemy.GetComponent<EnemyStats>().SetEnemyStats(i + 1); //#FIXME? tum objeler tek bir noktadan deger almali? EnemyConstructor gibi? \ Corpyr.
            tempEnemy.GetComponent<EnemyMovement>().waypoints = enemyWaypoints;

            yield return new WaitForSeconds(enemySpawnTime);

        }

    }

}
