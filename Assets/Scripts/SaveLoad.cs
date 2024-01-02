using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveLoad : MonoBehaviour
{
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    private Vector3 localPosition;
    [SerializeField] Transform canvasTransform;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)) Save();
        if(Input.GetKeyDown(KeyCode.F9)) Load();
    }

    void Save()
    {

        
    }
    void Load()
    {

    }

    private void Coordinates(GameObject go)
    {
        screenPosition = go.transform.position;
        screenPosition.z = -Camera.main.transform.position.z;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        localPosition = canvasTransform.InverseTransformPoint(worldPosition);
    }
}
