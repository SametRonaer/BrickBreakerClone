using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    GameObject gameManager;
    GameObject collidedBrick;
    ScoreManager scoreManager;

  
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Brick")
        {
            collidedBrick = collision.gameObject;
            //print(collision.gameObject.name);
            SendMessage("PlayParticle", collidedBrick);
            SendMessage("UpdateBrickLife", collidedBrick);
            SendMessage("ChangeBrickColour", collidedBrick);
            UpdateScore();

        }



        //if(collision.gameObject.tag == "Ground")
        //{
        //    print(collision.gameObject.tag);
        //    SetThrowPosition();
        //    DestroyBall();
        //}

    }

    public void UpdateScore()
    {
        scoreManager.UpdateScore();
    }


    private void DestroyBall()
    {
        
    }

    private void SetThrowPosition()
    {
        gameManager.GetComponent<GameManager>().SetThrowPosition(gameObject);
    }
}
