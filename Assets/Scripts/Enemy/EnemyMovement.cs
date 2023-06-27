using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;



/* Canavar hareketi bir noktadan diger noktaya, onceki gittigi noktalara geri gitmemek
 * sartiyla, gitmekten ibarettir. Bunu bir vector3 listesi ve bi,r index degeriyle yapariz.
 * \ Corpyr.
 */
public class EnemyMovement : MonoBehaviour
{
    public EnemyStats stats;
    
    //Vector3 lerle ugrasmamak icin direkt GameObject olarak waypointler alinir. \ Corpyr.
    public List<GameObject> waypoints;

    private List<Vector3> waypointVectors;

    private int currentWaypointIndex;

    void Start()
    {

        currentWaypointIndex = 0;
        waypointVectors = waypoints.Select(w => w.transform.position).ToList();

    }

    private void Update() {

        Move();

    }

    public void Move(){

        _moveToPoint();

        //Daginik gruplarda Vector3.Distance kullanilabilir. \ Corpyr.
        if(Vector3.Distance(transform.position, waypointVectors[currentWaypointIndex]) < 0.01f){ _increseWaypointIndex(); }

        _checkAndStopMovement();


    }


    private void _moveToPoint(){

        transform.position = Vector3.MoveTowards(transform.position, waypointVectors[currentWaypointIndex], stats.enemyMoveSpeed * Time.deltaTime);

    }

    private void _increseWaypointIndex(){

        currentWaypointIndex++; 

    }

    private void _checkAndStopMovement(){

        if(currentWaypointIndex > waypointVectors.Count - 1){ Destroy(this.gameObject); }

        //#TODO Dusman basariyla girerse son waypointe burda event yaz \ Corpyr.

    }
}
