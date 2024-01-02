using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform from;
    public Transform to;
    void Start()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0.08f, 0.9f), new Vector3(0, 0, 1), new Vector3(0, -0.08f, 0.9f) };
        lr.positionCount = points.Length;
        lr.SetPositions(points);
    }
    void Update()
    {
        transform.position = from.position;
        transform.LookAt(to);
        float mag = (from.position - to.position).magnitude;
        transform.localScale = new Vector3(mag, mag, mag);
    }
}
