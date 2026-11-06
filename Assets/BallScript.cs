using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Collider2D RightPaddle;
    public Collider2D LeftPaddle;
    public Collider2D ballCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collider2D collider)
    {
        float ballCentreY = ballCollider.bounds.center.y;
        float paddleCentreRY = RightPaddle.bounds.center.y;
        float paddleCentreLY = LeftPaddle.bounds.center.y;

        if (collider == RightPaddle)
        {
            
        }
    }
}
