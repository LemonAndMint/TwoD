using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerStats))]
public class TowerEventHandler : MonoBehaviour
{
    public UnityEvent<int> onSell;

    private TowerStats towerStats;

    void Start()
    {
        towerStats = GetComponent<TowerStats>();
    }

    public void invokeSell(){

        onSell.Invoke(towerStats.GetInGameID());

    }
}
