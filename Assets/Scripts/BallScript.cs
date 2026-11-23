using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


// Main class:
public class BallScript : MonoBehaviour
{
    public BoxCollider2D RightPaddle;
    public BoxCollider2D LeftPaddle;
    public BoxCollider2D ballCollider;
    public Rigidbody2D ballBody;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D lastPaddleHit;
    public ScoreScript scoreManager;
    float maxVelocity = 10f;
    int gameMode = GameValues.maxScore;
    Vector2 startPositionLP;
    Vector2 startPositionRP;
    Vector2 startPositionBall; 
    

    // Start is called before the first frame update
    void Start()
    {
        ballBody.velocity = new Vector2(maxVelocity, ballBody.velocity.y);
        startPositionLP = LeftPaddle.transform.position;
        startPositionRP = RightPaddle.transform.position;
        startPositionBall = ballBody.transform.position;
        lastPaddleHit = null;
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();
    }
    
    // Calculate the velocity of the ball on the Y-axis after hitting a paddle:
    private float calcVerticalVelocity(float ballPosY, float surfacePosY, BoxCollider2D surface)
    {
        float surfaceHeight = surface.bounds.size.y;
        float collisionPointY = ballPosY - surfacePosY;
        float normPosition = collisionPointY / (surfaceHeight/2);
        float verticalVelocity = normPosition * maxVelocity;

        return verticalVelocity;
    }

    // Calculate the velocity of the ball on the X-axis after hitting a paddle:
    private float calcHorizontalVelocity(float ballPosX, float surfacePosX, BoxCollider2D surface)
    {
        float surfaceLength = surface.bounds.size.x;
        float collisionPointX = ballPosX - surfacePosX;
        float normPosition = collisionPointX / (surfaceLength/2);
        float horizontalVelocity = normPosition * maxVelocity;

        return horizontalVelocity;
    }   

    // Function to set the ball's new X and Y positions following a paddle collision:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float ballVelocityY;
        float ballVelocityX;
        float ballCentreY = ballCollider.bounds.center.y;
        float paddleCentreRY = RightPaddle.bounds.center.y;
        float paddleCentreLY = LeftPaddle.bounds.center.y;

        if (collision.collider == RightPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreRY, RightPaddle);
            ballVelocityX = -maxVelocity;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
            lastPaddleHit = RightPaddle;
        }
        else if (collision.collider == LeftPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreLY, LeftPaddle);
            ballVelocityX = maxVelocity;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
            lastPaddleHit = LeftPaddle;
        }
        else if (collision.collider == topWall)
        {
            ballVelocityY = -maxVelocity;
            
            if (lastPaddleHit == RightPaddle)
            {
                ballBody.velocity = new Vector2(-maxVelocity, ballVelocityY);
                Debug.Log(ballBody.velocity.x);
            }
            else if (lastPaddleHit == LeftPaddle)
            {
                ballBody.velocity = new Vector2(maxVelocity, ballVelocityY);
                Debug.Log(ballBody.velocity.x);
            }
            
        }
        else if (collision.collider == bottomWall)
        {
            ballVelocityY = maxVelocity;
            
            if (lastPaddleHit == RightPaddle)
            {
                ballBody.velocity = new Vector2(-maxVelocity, ballVelocityY);
            }
            else if (lastPaddleHit == LeftPaddle)
            {
                ballBody.velocity = new Vector2(maxVelocity, ballVelocityY);
            }
        }
    }

    // Function for setting the game mode variable depending on which mode was selected.
    public void SetMode(String mode)
    {
        if (mode == "TEN")
        {
            gameMode = 10;
        }
        else if (mode == "FIVE")
        {
            gameMode = 5;
        }
    }

    //Updates player score depending on which side the ball leaves the game scene:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == leftWall)
        {
            scoreManager.updateRightScore();
        }
        else if (collision == rightWall)
        {
            scoreManager.updateLeftScore();
        } 

        //Reset ball and padddles to starting positions:
        LeftPaddle.transform.position = startPositionLP;
        RightPaddle.transform.position = startPositionRP;
        ballBody.transform.position = startPositionBall;
    }

    private void CheckScore()
    {
        if (scoreManager.GetHighestScore() == gameMode)
        {
            Debug.Log("GAME!");
        }    
    }
}
