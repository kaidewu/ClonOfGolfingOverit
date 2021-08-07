using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lr;
    public BallMovement ball;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 BallPosition, Vector3 endPoint)
    {
        BallPosition = ball.transform.position;
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = BallPosition;
        points[1] = endPoint;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
