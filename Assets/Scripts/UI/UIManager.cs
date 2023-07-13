using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject itemUIGrid;

    [SerializeField]
    private List<GameObject> tileImageList;

    private void Start() {
        
        GameObject tempGameObject;

            foreach(GameObject tileImage in tileImageList){

                tempGameObject = Instantiate(tileImage);
                tempGameObject.transform.SetParent(itemUIGrid.transform);
            }

    }

}
