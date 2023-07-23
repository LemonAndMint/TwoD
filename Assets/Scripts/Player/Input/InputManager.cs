using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour //MonoBehavior olmali mi? Sade C# kodu da olabilir. \ Corpyr. 
{

    public PlayerActions playerActions;
    public static InputManager instance; //#FIXME Private olnali, her component degistirebilir. \ Corpyr.
    public static Vector2 crusorPosInScreen;

    [SerializeField]
    private GameObject _BaseUISpritePrefab;
    private GameObject _AttachedSpriteGameObject;
    private TowerData _placingTowerSO;
    private Vector3 _crusorPosInGame;


    private void Awake() {

        if(instance == null){

            instance = this; //Classin singleton kismi \ Corpyr.

            SetSpriteNull();

        }

    }

    void Update()
    {
        crusorPosInScreen = Input.mousePosition;
        _syncSpriteAndCrusor();
        _checkButtonClicks();
    }

    public void BuyInput(TowerData towerSO){

        _AttachedSpriteGameObject = Instantiate(_BaseUISpritePrefab);
        _AttachedSpriteGameObject.GetComponent<SpriteRenderer>().sprite = towerSO.TowerUISprite;
        _placingTowerSO = towerSO;

    }

    public void SellInput(int towerInGameID){

        playerActions.SellTower(towerInGameID);

    }

    private void _syncSpriteAndCrusor(){

        if(_AttachedSpriteGameObject != null){

            _crusorPosInGame = Camera.main.ScreenToWorldPoint(crusorPosInScreen);
            _crusorPosInGame = new Vector3(_crusorPosInGame.x, _crusorPosInGame.y, 0);

            _AttachedSpriteGameObject.transform.position = _crusorPosInGame;
        
        }

    }

    private void _checkButtonClicks(){

        if(Input.GetMouseButtonDown(0)){

            if(_AttachedSpriteGameObject != null){

                playerActions.BuyTower(_placingTowerSO);

            }

        }

    }

    

    public void SetSpriteNull(){

        if(_AttachedSpriteGameObject != null) { Destroy(_AttachedSpriteGameObject.gameObject); }
        _AttachedSpriteGameObject = null;

    }


}
