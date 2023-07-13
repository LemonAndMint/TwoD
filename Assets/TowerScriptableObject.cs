using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Entities/Tower")]
public class TowerScriptableObject : ScriptableObject
{
    public GameObject TowerPrefab;
    public Sprite TowerUISprite;
}
