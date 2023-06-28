using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int gold;


    public void gainGold(int goldValue){

        gold += goldValue;

    }

    public void loseGold(int goldValue){

        gold -= goldValue;

    }

    public bool checkGold(){

        if (gold > 0f)
        {
            return true;
        }

        return false;

    }

}
