using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Using statement for unity UI code

using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //variable to track visible text score, public to let us drag and drop in the editor

    public Text scoreText;
    //variable to track numerical score, private because other scripts should not change it directly, default 0 as shouldnt have score when starting

    private int numericalScore = 0;


    // Use this for initialization
    void Start()
    {
        //get score from prefs datbase, use default of 0 if no score was saved, store result in numerical score variable
        numericalScore = PlayerPrefs.GetInt("score", 0);
        //update the visual score
        scoreText.text = numericalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //function to increase score, public so other scripts can use it, such as coin
    public void AddScore(int _toAdd)
    {
        // Add amount to numerical score
        numericalScore = numericalScore + _toAdd;
        //update visual score
        scoreText.text = numericalScore.ToString();
    }
    //function to save score to player preferences
    //public so it can be triggered from another script
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", numericalScore);
    }
}