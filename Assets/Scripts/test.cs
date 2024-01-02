using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 anchorPos = new Vector3(1, 1, 0);

        Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentPos.z = 0;

        Vector3 midPointVector = (currentPos + anchorPos) / 2;

        transform.position = midPointVector;

        Vector3 relative = currentPos - anchorPos;
        float maggy = relative.magnitude;


        transform.localScale = new Vector3(maggy / 2, 1, 0);
        Quaternion rotationVector = Quaternion.LookRotation(relative);
        rotationVector.z = 0;
        rotationVector.w = 0;
        transform.rotation = rotationVector;
    }
}
