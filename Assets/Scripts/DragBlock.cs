using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragBlock : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        if(GameObject.FindGameObjectWithTag("ToDelete"))
      GameObject.FindGameObjectWithTag("ToDelete").tag = "Block";
      gameObject.tag = "ToDelete";
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
