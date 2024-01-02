using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
    private void Update()
    {
       // if (Input.GetMouseButtonDown(0)) Debug.Log("Click");
    }
}
