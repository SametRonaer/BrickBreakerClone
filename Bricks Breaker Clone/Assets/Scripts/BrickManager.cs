using UnityEngine;
using System.Collections;
using System;

public class BrickManager: MonoBehaviour
{
    GameObject brickParticle, brickText  , brickBorder;
    TextMesh textMesh;
    int brickLife;
    Color brickColour;
    [SerializeField] float colourRatio = 0.2f;
  

    public void PlayParticle(GameObject brick)
    {
        brickParticle = brick.transform.GetChild(1).gameObject;
        brickParticle.GetComponent<ParticleSystem>().Play();
    }

    public void UpdateBrickLife(GameObject brick)
    {
        brickText = brick.transform.GetChild(0).transform.GetChild(1).gameObject;
        textMesh = brickText.GetComponent<TextMesh>();
        brickLife = (Int32.Parse(textMesh.text)-1);
        textMesh.text = (brickLife).ToString();
        if(brickLife <= 0)
        {
            KillBrick(brick);
        }
    }

    public void ChangeBrickColour(GameObject brick)
    {
        brickColour = brick.transform.GetChild(0).GetComponent<MeshRenderer>().material.GetColor("_myDiffuse");
        //print(brickColour);
        //brickColour = new Color(brickColour.r - colourChangeRatio, brickColour.g - colourChangeRatio, brickColour.b - colourChangeRatio);
        brick.transform.GetChild(0).GetComponent<MeshRenderer>().material.
            SetColor("_myDiffuse", new Color(1f,brickColour.g-colourRatio,brickColour.b+colourRatio,0));

    }

    public void KillBrick(GameObject brick)
    {
        Destroy(brick);
    }

  
}
