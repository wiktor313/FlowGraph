using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] private GameObject blockToSpawn1;
    [SerializeField] private GameObject blockToSpawn2;
    [SerializeField] private GameObject blockToSpawn3;
    [SerializeField] private GameObject blockToSpawn4;
    [SerializeField] private GameObject blockToSpawn5;
    [SerializeField] Transform canvasTransform;
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
    private void Coordinates()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = -Camera.main.transform.position.z;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        localPosition = canvasTransform.InverseTransformPoint(worldPosition);
    }
    private void Spawn()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn1, canvasTransform);
                bts.GetComponent<DragBlock>().lineMaker = GameObject.FindGameObjectWithTag("GameController").GetComponent<LineMaker>();
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn2, canvasTransform);
                bts.GetComponent<DragBlock>().lineMaker = GameObject.FindGameObjectWithTag("GameController").GetComponent<LineMaker>();
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn3, canvasTransform);
                bts.GetComponent<DragBlock>().lineMaker = GameObject.FindGameObjectWithTag("GameController").GetComponent<LineMaker>();
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn4, canvasTransform);
                bts.GetComponent<DragBlock>().lineMaker = GameObject.FindGameObjectWithTag("GameController").GetComponent<LineMaker>();
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                Coordinates();
                GameObject bts = Instantiate(blockToSpawn5, canvasTransform);
                bts.GetComponent<DragBlock>().lineMaker = GameObject.FindGameObjectWithTag("GameController").GetComponent<LineMaker>();
                bts.transform.SetLocalPositionAndRotation(localPosition, Quaternion.identity);
            }
        }
    }
}
