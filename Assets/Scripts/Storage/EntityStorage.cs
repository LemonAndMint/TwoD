using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utility;

public class EntityStorage : Storage
{
    private List<TowerStats> _inGameTowerList;
    [SerializeField]
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
    
    public void AddToStorage<T>(T item) where T : StorableStats{ //#FIXME? acaba event haline mi getirilmeli?

        if(typeof(T) == typeof(TowerStats)){

            StorageUtility.GiveMinID<TowerStats>(_inGameTowerList, (TowerStats)(StorableStats)item);
            _inGameTowerList.Add((TowerStats)(StorableStats)item); 



        }
        else if(typeof(T) == typeof(EnemyStats)){

            StorageUtility.GiveMinID<EnemyStats>(_inGameEnemyList, (EnemyStats)(StorableStats)item);
            _inGameEnemyList.Add((EnemyStats)(StorableStats)item);

            item.gameObject.GetComponent<EnemyHealth>().onDie.AddListener(RemoveFromStorage<EnemyStats>); //#TODO daha iyi bir sisteme oturt. \ Corpyr.

        }

    }

    public void RemoveFromStorage<T>(T item) where T : StorableStats{

        if(typeof(T) == typeof(TowerStats)){

            _inGameTowerList.Remove((TowerStats)(StorableStats)item);

        }
        else if(typeof(T) == typeof(EnemyStats)){

           _inGameEnemyList.Remove((EnemyStats)(StorableStats)item);

        }

    }

}