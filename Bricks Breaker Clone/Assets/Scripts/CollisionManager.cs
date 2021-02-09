using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    GameObject gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            print(collision.gameObject.tag);
            SetThrowPosition();
            DestroyBall();
        }
    }

    private void DestroyBall()
    {
        
    }

    private void SetThrowPosition()
    {
        gameManager.GetComponent<GameManager>().SetThrowPosition(gameObject);
    }
}
