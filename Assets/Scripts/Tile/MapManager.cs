using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

using System.Linq;
public class MapManager : MonoBehaviour
{
    public Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;
    private Dictionary<Vector3Int, bool> isTowerPresented;


    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }

        _prepPlaceableTileCoordinates(); // her zaman icin tiledatalar eklendikten sonra eklenmeli \Corpyr.

    }

    private void _prepPlaceableTileCoordinates(){

        isTowerPresented = new Dictionary<Vector3Int, bool>();
        TileData currentTileData = null;
        Vector3Int currentCoordinates;

        //Debug.Log("center:" + map.localBounds.center + "   " + "max:" + map.localBounds.max + "    " + "min:" + map.localBounds.min ); //#TODO
        
        for(int x = (int)map.localBounds.min.x; x < map.localBounds.max.x; x++ ){

            for(int y = (int)map.localBounds.min.y; y < map.localBounds.max.y; y++ ){

                currentCoordinates = new Vector3Int(x, y, 0);
                currentTileData = getTileData(currentCoordinates);

                if(currentTileData != null && currentTileData.canPlaceTower == true){ isTowerPresented.Add(currentCoordinates, false); }

            }

        }


        //Debug.Log(isTowerPresented.Count);

    }

    
    public bool placeTower(GameObject towerPrefab){

        Vector2 placingPoint = InputManager.crusorPosInScreen;

        Vector2 placingWorldPoint = Camera.main.ScreenToWorldPoint(placingPoint);
        Vector3Int gridIntPosition = map.WorldToCell(placingWorldPoint);
        TileData selectedTileData = getTileData(gridIntPosition);

        GameObject tempTower;

        if(selectedTileData != null && selectedTileData.canPlaceTower == true && isTileEmpty(gridIntPosition) == true){

            /* 
             * Konum icin Vector3Int kullanildigi icin ve TileMap offset degeri 0.5f e onceden ayarlandigindan
             * gridIntPosition direkt olarak oyun icindeki tile larin konumunu alamiyor. Asagidaki satirda ekstradan 
             * +0.5f lik bir ekleme yapilir. \ Corpyr. 
             */

            tempTower = Instantiate(towerPrefab); //#TODO baska bir kule varmi kontrolu yok \ Corpyr.
            
            Vector3 gridPositioninWorld = gridIntPosition + Vector3.one * 0.5f; 
            tempTower.transform.position = gridPositioninWorld;

            isTowerPresented[gridIntPosition] = true;

            return true;

        }

        return false;

    }

    private bool isTileEmpty(Vector3Int tilePosition){

        
        if(isTowerPresented.ContainsKey(tilePosition) != false && isTowerPresented[tilePosition] == false){

            return true;

        }

        return false;

    }

    public TileData getTileData(Vector3Int tilePosition)
    {
        TileBase tile = map.GetTile(tilePosition);

        if (tile == null)
            return null;

        if(dataFromTiles.ContainsKey(tile)){
            return dataFromTiles[tile];
        }

        return null;
    }
}