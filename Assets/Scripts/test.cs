using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Camera _mainCamera;
    private Renderer _renderer;
    private Ray _ray;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            _ray = new Ray(
                _mainCamera.ScreenToWorldPoint(Input.mousePosition),
                _mainCamera.transform.forward);
            if(Physics.Raycast(_ray, out _hit, 1000f))
            {
               if(_hit.transform == transform) 
                {
                    Debug.Log("Click");
                }
            }
        }
    }
}
