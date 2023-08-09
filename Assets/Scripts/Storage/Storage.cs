using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Storage<T> where T : StorableStats 
{
    [SerializeField]
    private List<T> _objectList;

    private static Storage<T> instance = null;

    public static Storage<T> Instance {

        get{ 
            
            if( instance == null ){ instance = new Storage<T>(); }
            
            return instance; 
            
        } 
        
        private set{}

    }

    public Storage() {

        _setupLists();

    }

    private void _setupLists(){

        _objectList = new List<T>();

    }
    
    public void AddToStorage(T item)
    {
        int id = StorageUtility.GetMinID<T>(_objectList, item);
        item.SetInGameID(id);
        _objectList.Add(item);

    }
    
    public void RemoveFromStorage(int id)
    {
        _objectList.Remove(GetItem(id));
    }

    public T GetItem(int id)
    {
        return StorageUtility.FindStat<T>(_objectList, id);
    }

}
