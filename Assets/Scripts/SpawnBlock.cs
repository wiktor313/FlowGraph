using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpawnBlock : MonoBehaviour
{
    [SerializeField] GameObject blockToSpawn1;
    [SerializeField] GameObject blockToSpawn2;
    [SerializeField] GameObject blockToSpawn3;
    [SerializeField] GameObject blockToSpawn4;
    [SerializeField] GameObject blockToSpawn5;
    [SerializeField] Transform canvasTransform;
    [SerializeField] Camera mainCamera;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    private Vector3 localPosition;
    void Update()
    {
        
        if (!EventSystem.current.currentSelectedGameObject)
        {
            Spawn();
        }
    }
    public void Coordinates()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = -mainCamera.transform.position.z;
        worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        localPosition = canvasTransform.InverseTransformPoint(worldPosition);
    }
    public void Spawn()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn1, canvasTransform);
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn2, canvasTransform);
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn3, canvasTransform);
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn4, canvasTransform);
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn5, canvasTransform);
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
        }
    }
}
