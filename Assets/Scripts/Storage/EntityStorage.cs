using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    
    public void AddToStorage<T>(StorageType storageType, T item) where T : Stats{

        if(typeof(T) == typeof(TowerStats)){

            _inGameTowerList.Add((TowerStats)(Stats)item); //?????????????????????????????? \ Corpyr.

        }
        else if(typeof(T) == typeof(EnemyStats)){

            _inGameEnemyList.Add((EnemyStats)(Stats)item);

        }

    }

}