using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulate : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject marker;
    [SerializeField] float ballSpeed = 200;
    [SerializeField] float markerSpace = 0.1f;
    [SerializeField] int markerCount = 30;
    [SerializeField] int simulationSpeed = 10;

    //List<GameObject> markers;
    GameObject[] markers;
    int currentMarker = 0;
    Touch touch;
    Vector3 direction;
    public Vector3 initialPos;
    bool resetTrajectory = true;

    private void Awake()
    {
        markers = new GameObject[markerCount];
        CreateMarkers();
        initialPos = ball.transform.position;
        Time.timeScale = simulationSpeed;
    }

    

    private void CreateMarkers()
    {
       for(int i = 0; i<markerCount; i++)
        {
            markers[i] = Instantiate(marker, marker.transform.position, marker.transform.rotation);
        }
    }

    private void Update()
    {
        SetRotation();
    }


    void SetRotation()
    {
        Vector3 touchPos, ballPos;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = touch.position;
            ballPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            //print(touchPos + "Touch");
            //print(ballPos + " ball");
            direction = touchPos - ballPos;
            direction = Vector3.Normalize(direction);
            //print(direction + " Direction");
            //DrawRay(direction);
            if (touch.phase == TouchPhase.Began)
            {
                Time.timeScale = simulationSpeed;
                SetBallPosition();
                PushBall();
                DrawMarker();
                // DrawRay(direction);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                Time.timeScale = 1;
                ClearMarkerList();
                SetBallPosition();
                print("Clear");
            }else if(touch.phase == TouchPhase.Moved)
            {
                if(touch.deltaPosition.magnitude > 3)
                {
                    Time.timeScale = simulationSpeed;
                    //ClearMarkerList();
                    currentMarker = 0;
                    SetBallPosition();
                    PushBall();
                    DrawMarker();
                    resetTrajectory = false;
                    //print(touch.deltaPosition.magnitude);
                }
                //Invoke("SetTrajectory", 0.1f);
            }
        }
    }

    private void SetTrajectory()
    {
        resetTrajectory = true;
    }

    private void SetBallPosition()
    {
        ball.transform.position = initialPos;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void PushBall()
    {
        ball.GetComponent<Rigidbody>().AddForce(direction * ballSpeed);
    }

    

    void ClearMarkerList()
    {
        foreach(GameObject g in markers)
        {
            g.transform.position = marker.transform.position;
        }
        currentMarker = 0;
        
    }

    private void DrawRay(Vector3 dir)
    {
        Debug.DrawRay(transform.position, direction * 100, Color.blue, 3);
    }

    void DrawMarker()
    {
        if (markerCount > currentMarker)
        {
            markers[currentMarker].transform.position = ball.transform.position;
            currentMarker++;
            
           
            Invoke("DrawMarker", markerSpace);

        }
    }
}
