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

            //tempGameObject = new GameObject(tileImage.name); //Bos bir obje yaratir klonlamaz
            tempGameObject = Instantiate(tileImage);
            tempGameObject.transform.SetParent(itemUIGrid.transform);
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Vector3Int gridPosition = map.WorldToCell(mousePosition);
            //TileBase clickedTile = map.GetTile(gridPosition);

        }
    }

    private void placeTower(){



    }

    public TileData getTileData(Vector3Int tilePosition)
    {
        TileBase tile = map.GetTile(tilePosition);

        if (tile == null)
            return null;
        else
            return dataFromTiles[tile];
    }
}