using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;
    [SerializeField]
    private List<GameObject> tileImageList;
    [SerializeField]
    private GridLayoutGroup itemUIGrid;

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

        GameObject tempGameObject;

        foreach(GameObject tileImage in tileImageList){

            tempGameObject = Instantiate(tileImage);
            tempGameObject.transform.SetParent(itemUIGrid.transform);
        }

    }

    public bool placeTower(GameObject towerGameObject, Vector2 placingPoint){

        Vector2 placingVector2 = Camera.main.ScreenToWorldPoint(placingPoint);
        Vector3Int gridIntPosition = map.WorldToCell(placingVector2);
        TileData selectedTileData = getTileData(gridIntPosition);

        if(selectedTileData != null && selectedTileData.canPlaceTower == true){

            /* 
             * Konum icin Vector3Int kullanildigi icin ve TileMap offset degeri 0.5f e onceden ayarlandigindan
             * gridIntPosition direkt olarak oyun icindeki tile larin konumunu alamiyor. Asagidaki satirda ekstradan 
             * +0.5f lik bir ekleme yapilir. \ Corpyr. 
             */
            
            Vector3 gridPositioninWorld = gridIntPosition + Vector3.one * 0.5f; 
            towerGameObject.transform.position = gridPositioninWorld;

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