using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float ballSpeed = 200;
    Touch touch;
    Vector3 direction;
    GameObject physicManager;

    private void Start()
    {
        Invoke("GetPhysicsManager", 0.3f);

    }

    private void GetPhysicsManager()
    {
        physicManager = GameObject.Find("PhysicsManager");
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
            if (touch.phase == TouchPhase.Ended)
            {
                PushBall();
                DrawRay(direction);
            }
        }
    }

    private void PushBall()
    {
        ball.GetComponent<Rigidbody>().AddForce(direction * ballSpeed);
    }


    public void SetThrowPosition(GameObject g)
    {
        physicManager.GetComponent<Simulate>().initialPos = g.transform.position;
    }


    private void DrawRay(Vector3 dir)
    {
        Debug.DrawRay(transform.position, direction * 100, Color.blue, 3);
    }
}
