using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //variable to let us add to score, public so we can drag and drop
    public Score scoreObject;

    //variable to hold coins point value, public so we can change in the editor
    public int coinValue;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //unity calls this function when our coin touches any other object 
    //if the player touched us, the count should vanish and score go up
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the thing we touched was the player 
        Player playerScript = collision.collider.GetComponent<Player>();
        //if thing we touched has player script, it is player, so...
        if (playerScript)
        {
            //we hit the player!
            //add score based on value
            scoreObject.AddScore(coinValue);
            //kill gameObject that script is attached to 
            Destroy(gameObject);
        }
    }
}
