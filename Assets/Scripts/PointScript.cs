using UnityEngine;
using UnityEngine.EventSystems;

public class PointScript : MonoBehaviour
{
    [SerializeField] GameObject resizeObject;
    [SerializeField] float resizeSpeed = 0.1f;

    private void OnMouseDrag()
    {
        if(Input.GetAxis("Mouse X")>0) resizeObject.transform.localScale += new Vector3 (resizeSpeed,resizeSpeed,resizeSpeed);
        if(Input.GetAxis("Mouse X")<0) resizeObject.transform.localScale -= new Vector3 (resizeSpeed,resizeSpeed,resizeSpeed);
        if(Input.GetAxis("Mouse Y")>0) resizeObject.transform.localScale += new Vector3 (resizeSpeed,resizeSpeed,resizeSpeed);
        if(Input.GetAxis("Mouse Y")<0) resizeObject.transform.localScale -= new Vector3 (resizeSpeed,resizeSpeed,resizeSpeed);
    }

}