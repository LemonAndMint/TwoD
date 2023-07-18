using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileData", menuName = "Entities/Tile")]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public bool isWalkable; 

    public bool canPlaceTower;

}
