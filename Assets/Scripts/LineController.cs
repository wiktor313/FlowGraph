using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] public Transform[] points;
    Vector3 upperPoint;
    Vector3 lowerPoint;
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
        lineRenderer.positionCount = 5;
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
                    
                    lineRenderer.SetPosition(i, new Vector3 (points[i].position.x, points[i].position.y,13));
                    DrawArrowHead();
                    lineRenderer.SetPosition(2, new Vector3(upperPoint.x, upperPoint.y, 13));
                    lineRenderer.SetPosition(3, new Vector3(lowerPoint.x,lowerPoint.y,13));
                    lineRenderer.SetPosition(4, new Vector3(points[i].position.x, points[i].position.y, 13));
                }
            }
        }
    }
    void DrawArrowHead()
    {
            int arrowHeadLength = 5;
            Vector3 direction = points[1].position - points[0].position;
            Vector3 directionNormalized = direction.normalized;
            directionNormalized = -directionNormalized;
            float angle = Mathf.Atan2(directionNormalized.y, directionNormalized.x);
            float upperAngle = angle + (Mathf.PI / 6);
            float lowerAngle = angle - (Mathf.PI / 6);

            Vector3 upperDirection = new Vector3(Mathf.Cos(upperAngle), Mathf.Sin(upperAngle), 13);
            Vector3 lowerDirection = new Vector3(Mathf.Cos(lowerAngle), Mathf.Sin(lowerAngle), 13);

            upperPoint = new Vector3((points[1].position.x + upperDirection.x * arrowHeadLength), (points[1].position.y + upperDirection.y * arrowHeadLength), 0);
            lowerPoint = new Vector3((points[1].position.x + lowerDirection.x * arrowHeadLength), (points[1].position.y + lowerDirection.y * arrowHeadLength), 0);
    }
}
