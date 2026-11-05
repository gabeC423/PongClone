using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LeftPaddleMovement : MonoBehaviour
{
    public Rigidbody2D PaddleBody;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PaddleBody.velocity = Vector2.up * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PaddleBody.velocity = Vector2.down * moveSpeed;
        }
        else
        {
            PaddleBody.velocity = Vector2.zero;
        }
    }
}
