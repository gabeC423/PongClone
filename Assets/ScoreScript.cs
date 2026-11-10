using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text rightSore;
    public TMP_Text leftScore;
    int scoreL = 0;
    int scoreR = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLeftScore()
    {
        scoreL += 1;
        leftScore.text = scoreL.ToString();
    }

    public void updateRightScore()
    {
        scoreR += 1;
        rightSore.text = scoreR.ToString();
    }
}
