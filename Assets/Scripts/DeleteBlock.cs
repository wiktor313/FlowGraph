using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteBlock : MonoBehaviour
{
    private GameObject lastClickedObject;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("ToDelete")) GameObject.FindGameObjectWithTag("ToDelete").tag="Block";
        if (GameObject.FindGameObjectWithTag("ToDelete") && Input.GetKeyDown(KeyCode.Delete) && !EventSystem.current.currentSelectedGameObject) 
        {
            lastClickedObject = GameObject.FindGameObjectWithTag("ToDelete");
            Destroy(lastClickedObject);
        }
    }
}
