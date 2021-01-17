using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 pToBVector;
    [SerializeField] Vector2 launchVelocity = new Vector2(2f, 15f);
    bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        pToBVector = transform.position - paddle1.transform.position;
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
            GetComponent<Rigidbody2D>().velocity = launchVelocity;
            launched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched)
        {
            GetComponent<AudioSource>().Play();

        }
    }
}
