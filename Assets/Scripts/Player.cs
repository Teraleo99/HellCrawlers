using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//extra using statement, for scene management functions
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    //variable to ref lives on display
    public Lives livesObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);

        // Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Give the velocity to the rigidbody
        physicsBody.velocity = velocity;

        //Tell animator our speed
        playerAnimator.SetFloat("WalkSpeed", Mathf.Abs(velocity.x));

        //Flip sprite!
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        //Jumping

        //detect if we touch ground
        //get layer mask from unity using name of layer

        LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        //ask player's collider if we touch layer mask

        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            //just pressed jump so set upward velocity to jump speed
            velocity.y = jumpSpeed;

            //give velociy to rigidbody
            physicsBody.velocity = velocity;
        }
    }

    //our own function for handling player death
    public void Kill()
    {
        //take away life and save that change
        livesObject.Loselife();
        livesObject.SaveLives();

        //check if its game over
        bool gameOver = livesObject.IsGameOver();

        if (gameOver == true)
        {
            //if is.............load game over scene
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            //if no..............
            //Reset current level to restart from beginning
            //first ask unity what current level is
            Scene currentLevel = SceneManager.GetActiveScene();

            //second, tell unity to load current level again, by passing build index of our level
            SceneManager.LoadScene(currentLevel.buildIndex);
        }
    }

}
