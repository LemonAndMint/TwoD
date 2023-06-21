using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;
    public MapManager mapManager;

    [SerializeField]
    private GameObject BaseUISprite;
    private GameObject AttachedSpriteGameObject;
    private Vector2 crusorPosInScreen;
    private Vector3 crusorPosInGame;


    private void Awake() {

        if(instance == null){

            instance = this; //Classin singleton kismi \ Corpyr.

            _setSpriteNull();
        
        }

    }

    void Update()
    {
        crusorPosInScreen = Input.mousePosition;
        _syncSpriteAndCrusor();
        _checkButtonClicks();
    }

    public void attachSpritetoCrusor(Sprite sprite){

        AttachedSpriteGameObject = Instantiate(BaseUISprite);
        AttachedSpriteGameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    
    }

    private void _syncSpriteAndCrusor(){

        if(AttachedSpriteGameObject != null){

            crusorPosInGame = Camera.main.ScreenToWorldPoint(crusorPosInScreen);
            crusorPosInGame = new Vector3(crusorPosInGame.x, crusorPosInGame.y, 0);

            AttachedSpriteGameObject.transform.position = crusorPosInGame;
        
        }

    }

    private void _checkPlacableTiles(){

        if(AttachedSpriteGameObject != null){

            

        }

    }

    private void _checkButtonClicks(){

        if(Input.GetMouseButtonDown(0)){

            if(AttachedSpriteGameObject != null){

                bool isPlaced = mapManager.placeTower(AttachedSpriteGameObject, crusorPosInScreen);
                
                if(isPlaced) _setSpriteNull();
            }

        }

    }

    private void _setSpriteNull(){

        AttachedSpriteGameObject = null;

    }

}
