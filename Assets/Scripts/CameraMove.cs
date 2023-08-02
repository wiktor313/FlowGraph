using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private float speed;
    private int maxHeight = 170;
    private void Start()
    {
       speed = 0.2f;
    }
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            speed += 0.2f;
            Debug.Log(speed.ToString());
        }
        else if (Input.mouseScrollDelta.y < 0 && speed>0.2f)
        { 
        speed -= 0.2f;
            Debug.Log(speed.ToString());
        }
        if (!EventSystem.current.currentSelectedGameObject)
        {

            float xAxisValue = Input.GetAxis("Horizontal") * speed;
            float yAxisValue = Input.GetAxis("Vertical") * speed;
            Vector3 newPosition = new Vector3(transform.position.x + xAxisValue, transform.position.y + yAxisValue, -10);
            newPosition.y = Mathf.Clamp(newPosition.y, float.MinValue, maxHeight);
            transform.position = newPosition;
        }
    }
}
