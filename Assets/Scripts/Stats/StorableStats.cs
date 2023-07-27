using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorableStats : Stats
{
    protected int _entityID;
    protected int _entityInGameID;

    public int GetInGameID(){

        return _entityInGameID;

    }

    public void SetInGameID(int id){

        _entityInGameID = id;

    }
}
