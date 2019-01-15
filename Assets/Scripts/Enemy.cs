using UnityEngine;

public class Enemy : MonoBehaviour
{
    //calls automatically when enemy touches any other object

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if thing we collided with is player (aka has player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //only do this if thing ran into is player
        if (playerScript != null)
        {
            //we did hit player!
            //KILL THEM
            playerScript.Kill();

        }
    }

}
