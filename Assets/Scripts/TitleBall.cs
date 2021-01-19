using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBall : MonoBehaviour
{
    // Ball State
    [SerializeField] Vector2 launchVelocity = new Vector2(2f, 15f);
    [SerializeField] AudioClip[] ballSounds;

    //Cache component references
    AudioSource ballAudioSource;
    Rigidbody2D ballRigidbody;

    int nextSound = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballAudioSource = GetComponent<AudioSource>();
        ballRigidbody.velocity = launchVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(nextSound == 0)
        {
            ballAudioSource.PlayOneShot(ballSounds[0]);
            nextSound = 1;
        }
        else
        {
            ballAudioSource.PlayOneShot(ballSounds[1]);
            nextSound = 0;
        }
    }
}
