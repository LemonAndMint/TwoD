using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utility;

public class EntityStorage : Storage
{
    private List<TowerStats> _inGameTowerList;
    private List<EnemyStats> _inGameEnemyList;

    public List<TowerStats> inGameTowerList{ 
        
        get{ return _inGameTowerList; } 
        
        private set{} 
        
    }

    public List<EnemyStats> inGameEnemyList{ 
        
        get{ return _inGameEnemyList; } 
        
        private set{} 
        
    }

    private static EntityStorage instance;

    public static EntityStorage Instance {

        get{ return instance; } 
        
        private set{}

    }

    private void Awake() {

        if( instance == null ){

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if( instance != this ){

            Destroy(gameObject);

        }

    }
    
    public void AddToStorage<T>(T item) where T : StorableStats{

        if(typeof(T) == typeof(TowerStats)){

            StorageUtility.GiveIDtoItem<TowerStats>(_inGameTowerList, (TowerStats)(StorableStats)item);
            _inGameTowerList.Add((TowerStats)(StorableStats)item); 


        }
        else if(typeof(T) == typeof(EnemyStats)){

            StorageUtility.GiveIDtoItem<EnemyStats>(_inGameEnemyList, (EnemyStats)(StorableStats)item);
            _inGameEnemyList.Add((EnemyStats)(StorableStats)item);

        }


    }

}