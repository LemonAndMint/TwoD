using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;
    public MapManager mapManager;

    [SerializeField]
    private List<GameObject> tileImageList;

    [SerializeField]
    private GameObject BaseUISprite;
    private GameObject AttachedSpriteGameObject;
    private string towerName;
    private Vector2 crusorPosInScreen;
    private Vector3 crusorPosInGame;


    private void Awake() {

        if(instance == null){

            instance = this; //Classin singleton kismi \ Corpyr.

            _setSpriteNull();

            GameObject tempGameObject;

            foreach(GameObject tileImage in tileImageList){

                tempGameObject = Instantiate(tileImage);
                tempGameObject.transform.SetParent(mapManager.itemUIGrid.transform);
            }
        
        }

    }

    void Update()
    {
        crusorPosInScreen = Input.mousePosition;
        _syncSpriteAndCrusor();
        _checkButtonClicks();
    }

    public void attachSpritetoCrusor(Sprite sprite, string towerName){

        AttachedSpriteGameObject = Instantiate(BaseUISprite);
        AttachedSpriteGameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        this.towerName = towerName;

    }

    private void _syncSpriteAndCrusor(){

        if(AttachedSpriteGameObject != null){

            crusorPosInGame = Camera.main.ScreenToWorldPoint(crusorPosInScreen);
            crusorPosInGame = new Vector3(crusorPosInGame.x, crusorPosInGame.y, 0);

            AttachedSpriteGameObject.transform.position = crusorPosInGame;
        
        }

    }

    private void _checkButtonClicks(){

        if(Input.GetMouseButtonDown(0)){

            if(AttachedSpriteGameObject != null){

                bool isPlaced = mapManager.placeTower(towerName, crusorPosInScreen);
                
                if(isPlaced) _setSpriteNull();
            }

        }

    }

    private void _setSpriteNull(){

        if(AttachedSpriteGameObject != null) { Destroy(AttachedSpriteGameObject.gameObject); }
        AttachedSpriteGameObject = null;

    }

}
