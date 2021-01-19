using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 pToBVector;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //Ball State
    bool launched = false;
    [SerializeField] Vector2 launchVelocity = new Vector2(2f, 15f);

    //Cache component references
    AudioSource ballAudioSource;
    Rigidbody2D ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        pToBVector = transform.position - paddle1.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        ballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
        
        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = paddle1.transform.position;
        transform.position = paddlePosition + pToBVector;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0) && !launched)
        {
            ballRigidbody.velocity = launchVelocity;
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
            launched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityAdjustment = new Vector2
            (
                UnityEngine.Random.Range(0f, randomFactor), 
                UnityEngine.Random.Range(0f, randomFactor)
            );

        if (launched)
        {
            if(collision.gameObject.name.Equals("Paddle")){
                ballAudioSource.PlayOneShot(ballSounds[0]);
            }else
            {
                ballAudioSource.PlayOneShot(ballSounds[1]);
            }
            ballRigidbody.velocity += velocityAdjustment;
        }
    }

    public void Reset()
    {
        launched = false;
    }
}
