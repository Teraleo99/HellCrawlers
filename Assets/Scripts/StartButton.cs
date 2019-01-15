using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allows us to use scene loading function
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void StartGame()
    {
        //Reset the score
        PlayerPrefs.DeleteKey("score");
        //Reset lives
        PlayerPrefs.DeleteKey("lives");
        //Load first level
        SceneManager.LoadScene("Level1");
    }

}