using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private BallScript ballScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sound collision");
        if (collision.collider == ballScript.RightPaddle || collision.collider == ballScript.LeftPaddle)
        {
            if (hitClip != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitClip);
            }
        }
    }
}
