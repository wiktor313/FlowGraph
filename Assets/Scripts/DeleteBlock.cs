using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlock : MonoBehaviour
{
    private GameObject lastClickedObject;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("ToDelete") && Input.GetKeyDown(KeyCode.Delete))
        {
            lastClickedObject = GameObject.FindGameObjectWithTag("ToDelete");
            Destroy(lastClickedObject);
        }
    }
}
