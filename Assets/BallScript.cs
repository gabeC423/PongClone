using Unity.VisualScripting;
using UnityEngine;

// Main class:
public class BallScript : MonoBehaviour
{
    public BoxCollider2D RightPaddle;
    public BoxCollider2D LeftPaddle;
    public BoxCollider2D ballCollider;
    public Rigidbody2D ballBody;
    float maxVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ballBody.velocity = new Vector2(maxVelocity, ballBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Calculate the velocity of the ball on the Y-axis after hitting a paddle:
    private float calcVerticalVelocity(float ballY, float paddleY, BoxCollider2D paddle)
    {
        float paddleHeight = paddle.size.y;
        float collisionPointY = ballY - paddleY;
        float normPosition = collisionPointY / (paddleHeight/2);
        float verticalVelocity = normPosition * maxVelocity;

        return verticalVelocity;
    }

    // Function to set the ball's new X and Y positions following a paddle collision:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float ballVelocityY = ballBody.velocity.y;
        float ballVelocityX = ballBody.velocity.x;
        float ballCentreY = ballCollider.bounds.center.y;
        float paddleCentreRY = RightPaddle.bounds.center.y;
        float paddleCentreLY = LeftPaddle.bounds.center.y;

        if (collision.collider == RightPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreRY, RightPaddle);
            ballVelocityX = -ballVelocityX;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
        else if (collision.collider == LeftPaddle)
        {
            ballVelocityY = calcVerticalVelocity(ballCentreY, paddleCentreLY, LeftPaddle);
            ballVelocityX = -ballVelocityX;
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
    }
}
