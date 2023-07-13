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

    }

    
    public bool placeTower(GameObject towerPrefab){

        Vector2 placingPoint = InputManager.crusorPosInScreen;

        Vector2 placingWorldPoint = Camera.main.ScreenToWorldPoint(placingPoint);
        Vector3Int gridIntPosition = map.WorldToCell(placingWorldPoint);
        TileData selectedTileData = getTileData(gridIntPosition);

        GameObject tempTower;

        if(selectedTileData != null && selectedTileData.canPlaceTower == true){

            /* 
             * Konum icin Vector3Int kullanildigi icin ve TileMap offset degeri 0.5f e onceden ayarlandigindan
             * gridIntPosition direkt olarak oyun icindeki tile larin konumunu alamiyor. Asagidaki satirda ekstradan 
             * +0.5f lik bir ekleme yapilir. \ Corpyr. 
             */

            tempTower = Instantiate(towerPrefab); //#TODO baska bir kule varmi kontrolu yok \ Corpyr.
            
            Vector3 gridPositioninWorld = gridIntPosition + Vector3.one * 0.5f; 
            tempTower.transform.position = gridPositioninWorld;

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