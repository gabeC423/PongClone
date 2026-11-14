using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleMovement : MonoBehaviour
{
    public Rigidbody2D PaddleBody;
    public float movespeed = 10f;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PaddleBody.velocity = Vector2.up * movespeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            PaddleBody.velocity = Vector2.down * movespeed;
        }
        else
        {
            PaddleBody.velocity = Vector2.zero;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Called wallCollision()" + collision.gameObject.name);
        if (collision.collider == bottomWall && Input.GetKey(KeyCode.DownArrow))
        {
            PaddleBody.velocity = Vector2.zero;
            Debug.Log("After: " + PaddleBody.velocity);
        }
        else if (collision.collider == topWall && Input.GetKey(KeyCode.UpArrow))
        {
            PaddleBody.velocity = Vector2.zero;
            Debug.Log("After: " + PaddleBody.velocity);
        }
    }

    
}
