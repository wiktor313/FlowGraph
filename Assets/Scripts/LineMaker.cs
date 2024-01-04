using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineMaker : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !EventSystem.current.currentSelectedGameObject)
        {
            Debug.Log("Klik");
            if (point1 != null && point2 != null)
            {
                Debug.Log("S¹ obiekty");
                GameObject go = (GameObject)(Resources.Load("Line"));
                Transform[] pointsToPush = { point1, point2 };
                go.GetComponent<LineController>().points = pointsToPush;
                Instantiate(go);
                point1 = null;
                point2 = null;
            }
        }
    }
}
