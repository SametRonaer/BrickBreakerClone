using UnityEngine;
using System.Collections;

public class ScoreManager: MonoBehaviour
{
    [SerializeField] GameObject scoreBar;
    [SerializeField] float scoreBarMove;
    float xPosition;
    [SerializeField]float lastXPosition = -1;

   
    public void UpdateScore()
    {
        xPosition = scoreBar.transform.localPosition.x;
        if (xPosition < lastXPosition)
        {
            scoreBar.transform.position += new Vector3(scoreBarMove, 0, 0);
        }
        else
        {
            print("Finish");
        }
    }

}
