using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    [SerializeField] GameObject main;
    GameObject[] points = new GameObject[4];
    private string newname;
    private void Start()
    {
        if (main.name.Contains("(Clone)"))
        {
            newname = main.name.Replace("(Clone)", "");
        }
        else newname = main.name;
        points = GameObject.FindGameObjectsWithTag($"Point{newname}");
    }
    void Update()
    {
        if (main.tag == "ToDelete")
        {
            foreach (GameObject go in points) 
            {
                go.SetActive(true);
            }
        }
        else for (int i = 0; i < 4; i++) foreach (GameObject go in points) go.SetActive(false);
    }
}
