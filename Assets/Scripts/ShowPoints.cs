using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    [SerializeField] GameObject main;
    GameObject point;
    private string newname;
    private void Start()
    {
        if (main.name.Contains("(Clone)"))
        {
            newname = main.name.Replace("(Clone)", "");
        }
        else newname = main.name;
        point = GameObject.FindGameObjectWithTag($"Point{newname}");
    }
    void Update()
    {
        if (main.tag == "ToDelete")
        {
                point.SetActive(true);
        }
        else point.SetActive(false);
    }
}
