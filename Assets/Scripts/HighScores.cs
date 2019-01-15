using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needed for working with text components

using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    //text component used to display high scores

    public List<Text> highScoreDisplays = new List<Text>();

    //internal data for score values

    private List<int> highScoreData = new List<int>();

    // Use this for initialization
    void Start()
    {
        //load score data from playerprefs

        LoadHighScoreData();

        //get our current score from playerprefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        //check if we got new high score
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)
        {
            //add new score and save updated data
            AddScoreToList(currentScore);
            //save updated data
            SaveHighScoreData();
        }

        //add new score to data
        //save updated data

        //update the visual display

        UpdateVisualDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //using loop index, get name for playerprefs key
            string prefsKey = "highScore" + i.ToString();

            //use this key to get high score value from playerprefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            //store this score value in our internal data list
            highScoreData.Add(highScoreValue);
        }
    }
    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //find specific text & numbers in list + set text to numerical score
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }
    private bool IsNewHighScore(int scoreToCheck)
    {
        //loop through high scores and see if ours is higher than any of them
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //is score higher than score we're checking this loop
            if (scoreToCheck > highScoreData[i])
            {
                //our score is higher! return to calling code that it IS higher
                return true;
            }
        }
        //default: false
        //did not find any scores that ours was higher than
        return false;

    }
    private void AddScoreToList(int newScore)
    {
        //loop thru high scores and find where new score fits
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            if (newScore > highScoreData[i])
            {
                //our score IS higher
                //since we're goig highest to lowest, first time our score is higher this is where this must go
                highScoreData.Insert(i, newScore);

                //trim last item off list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                //we're done, must exit early
                return;

            }
        }
    }

    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //using loop index, get name for playerprefs key
            string prefsKey = "highScore" + i.ToString();

            //get current high score entry from data
            int highScoreEntry = highScoreData[i];

            //save this data to playerprefs
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);

        }

        //save playerprefs to disc
        PlayerPrefs.Save();
    }
}
