using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] public Transform[] points;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        SetUpLine(points);
    }

    public void SetUpLine(Transform[] points)
    {
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }

    void Update()
    {
        if (points[1].IsDestroyed() || points[0].IsDestroyed()) Destroy(gameObject);
        else
        {
            if (!lineRenderer.IsDestroyed())
            {
                for (int i = 0; i < points.Length; i++)
                {
                    lineRenderer.SetPosition(i, points[i].position);
                }
            }
        }
    }
}
