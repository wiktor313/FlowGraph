using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CloseHelp : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject go;
    void Start()
    {
        bt.onClick.AddListener(Close);
    }
    void Close()
    {
        go.SetActive(false);
    }
}
