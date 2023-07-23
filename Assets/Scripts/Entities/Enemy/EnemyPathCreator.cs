using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPathCreator : MonoBehaviour
{
    public Tile startTile;
    public Tile endTile;

    public MapManager mapManager;

    private Tilemap map;

    private void Awake() {
        
        map = mapManager.map;

        Debug.Log( map.cellBounds.max );
        Debug.Log( map.cellBounds.min );

        mapManager = GetComponent<MapManager>();

    }

    /*public List<Vector2> createPath(){

        List<Vector2> path = new List<Vector2>();


        for (int i = 0; i < length; i++)
        {
            for (int i = 0; i < length; i++)
            {
                
            }
        }

    }
*/
}
