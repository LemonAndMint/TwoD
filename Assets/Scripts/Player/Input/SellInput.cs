using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerStats))]
public class SellInput : MonoBehaviour
{
    public InputManager inputManager; //Singleton bir yapidadir. \Corpyr.
    private TowerStats towerStats;

    void Start()
    {
        towerStats = GetComponent<TowerStats>();
        inputManager = InputManager.Instance;
    }

    public void SellEvent(){

        inputManager.SellInput(towerStats.GetInGameID());
        Destroy(gameObject);

    }

}
