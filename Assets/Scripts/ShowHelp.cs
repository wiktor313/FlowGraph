using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHelp : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject go;
    void Start()
    {
        bt.onClick.AddListener(Show);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
        {
            Show();
        }
    }
    void Show()
    {
        go.SetActive(true);
    }
}
