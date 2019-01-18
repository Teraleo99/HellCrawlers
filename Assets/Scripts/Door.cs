using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//extra using statement, for scene management functions
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{

    //Designer variables
    //variable to let us save the score, public so we can drag and drop
    public Score scoreObject;
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if thing we collided with is player (aka has player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //only do this if thing ran into is player
        if (playerScript != null)
        {
            //we did hit player!
            //save score using our score object reference
            scoreObject.SaveScore();
            //Load next level
            SceneManager.LoadScene(sceneToLoad);

        }
    }
}
