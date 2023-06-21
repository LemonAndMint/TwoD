using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    [SerializeField]
    private GameObject BaseUISprite;
    private GameObject AttachedSpriteGameObject;
    private Vector2 crusorPos;


    private void Awake() {

        if(instance == null){

            instance = this; //Classin singleton kismi \ Corpyr.

            AttachedSpriteGameObject = null;
        
        }

    }

    void Update()
    {
        crusorPos = Input.mousePosition;
        syncSpriteAndCrusor();
    }

    public void atachSpritetoCrusor(Sprite sprite){

        AttachedSpriteGameObject = Instantiate(BaseUISprite);
        AttachedSpriteGameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    
    }

    private void syncSpriteAndCrusor(){

        if(AttachedSpriteGameObject != null){

            AttachedSpriteGameObject.transform.position = Camera.main.ScreenToWorldPoint(crusorPos);
        
        }

    }

}
