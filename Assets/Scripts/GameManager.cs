using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManager instace;
    // Start is called before the first frame update
    void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }
    #endregion

    Camera cam;
    public BallMovement ball;
    public RadiusDrag_Src radiusDrag;
    TrajectoryLine tl;

    [SerializeField] float pushForce = 4f;
    bool isDragging = false;
    bool ready;
    Vector3 endPointDrag;

    Vector3 lastPosition;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 direction;
    Vector3 force;
    public Vector3 ballPosition;
    float distance;
    void Start()
    {
        cam = Camera.main;
        ball.DesactivateRb();
        tl = GetComponent<TrajectoryLine>();
        radiusDrag = GetComponent<RadiusDrag_Src>();
    }

    private void Update()
    {
        
        //ballPosition = GameObject.FindGameObjectsWithTag("player")[0].transform.position;

        if (ball.rb.IsSleeping())
        {

            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();

            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
                tl.EndLine();

            }
            if (isDragging)
            {
                OnDrag();
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                tl.RenderLine(startPoint, currentPoint);
            }
        }

        //Another code 
        /*if (lastPosition == player.transform.position)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();

            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();

            }
            if (isDragging)
            {
                OnDrag();
            }
        }

        lastPosition = player.transform.position;*/

    }

    //-Drag---------------------------------------


    public void BallPosition()
    {
        ballPosition = ball.transform.position;
    }

   public void RadiusDrag()
    {
        Vector3 radius = new Vector3(Range(ballPosition, -ballPosition), );
    }

    void OnDragStart()
    {
        //ball.DesactivateRb();
        //startPoint = cam.ScreenToWorldPoint(ballPosition);
        BallPosition();

    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        //endPoint = cam.ScreenToWorldPoint(radiusDrag.endPointDrag);
        distance = Vector3.Distance(ballPosition, endPoint);
        direction = (ballPosition - endPoint).normalized;
        force = direction * distance * pushForce;

        //Just for debug
        Debug.DrawLine(ballPosition, endPoint);

    }

    void OnDragEnd()
    {
        //push de ball
        ball.ActivateRb();
        ball.Push(force);
        ball.Sound();
    }
}
