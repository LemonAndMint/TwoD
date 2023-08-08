using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utility;

public class EntityStorage : MonoBehaviour, IStorage  
{
    [SerializeField]
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
            _setupLists();
            DontDestroyOnLoad(gameObject);

        }
        else if( instance != this ){

            Destroy(gameObject);

        }

    }

    private void _setupLists(){

        _inGameTowerList = new List<TowerStats>();
        _inGameEnemyList = new List<EnemyStats>();

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

    public void RemoveFromStorage<T>(T item) where T : StorableStats{ //#FIXME? Sadece id ile mi olmalı?

        if(typeof(T) == typeof(TowerStats)){

            _inGameTowerList.Remove((TowerStats)(StorableStats)item);

        }
        else if(typeof(T) == typeof(EnemyStats)){

           _inGameEnemyList.Remove((EnemyStats)(StorableStats)item);

        }

    }

    public void RemoveFromStorage<T>(int id) where T : StorableStats{

        if(typeof(T) == typeof(TowerStats)){

            _inGameTowerList.Remove(StorageUtility.FindStat<TowerStats>(_inGameTowerList, id));

        }
        else if(typeof(T) == typeof(EnemyStats)){

           _inGameEnemyList.Remove(StorageUtility.FindStat<EnemyStats>(_inGameEnemyList, id));

        }

    }

    public T GetStat<T>(int id) where T : StorableStats{

        if(typeof(T) == typeof(TowerStats)){

            return (T)(object)StorageUtility.FindStat<TowerStats>(_inGameTowerList, id);

        }
        else if(typeof(T) == typeof(EnemyStats)){

            return (T)(object)StorageUtility.FindStat<EnemyStats>(_inGameEnemyList, id);

        }

        return null;

    }

}