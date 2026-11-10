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
    public ScoreScript scoreManager;
    float maxVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ballBody.velocity = new Vector2(maxVelocity, ballBody.velocity.y);
        Debug.Log("Start: " + ballBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Before: " + ballBody.velocity);
        float ballVelocityY = ballBody.velocity.y;
        float ballVelocityX = ballBody.velocity.x;
        float ballCentreY = ballCollider.bounds.center.y;
        float paddleCentreRY = RightPaddle.bounds.center.y;
        float paddleCentreLY = LeftPaddle.bounds.center.y;
        float wallCentreT = topWall.bounds.center.x;
        float wallCentreB = bottomWall.bounds.center.x;

        if (collision.collider == RightPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreRY, RightPaddle);
            ballVelocityX = -maxVelocity;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
        else if (collision.collider == LeftPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreLY, LeftPaddle);
            ballVelocityX = maxVelocity;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
        else if (collision.collider == topWall)
        {
            ballVelocityX = calcHorizontalVelocity(ballCentreY, wallCentreT, topWall);
            ballVelocityY = -maxVelocity + Random.Range(-1,10);
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
        else if (collision.collider == bottomWall)
        {
            ballVelocityX = calcHorizontalVelocity(ballCentreY, wallCentreB, bottomWall);
            ballVelocityY = maxVelocity + Random.Range(-1,10);
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }


        Debug.Log("After: " + ballBody.velocity);
    }

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
    }
}
