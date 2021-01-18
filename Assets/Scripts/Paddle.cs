using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1.23f;
    [SerializeField] float maxX = 14.76f;
    [SerializeField] Ball gameBall;
    [SerializeField] bool autoPlay = false;
    [SerializeField] bool titleScreen = false;

    // Update is called once per frame
    void Update()
    {
        if (titleScreen){return;}

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        if (!autoPlay)
        {
            float mouseXPosition = (Input.mousePosition.x / Screen.width * screenWidthUnits);
            paddlePosition.x = Mathf.Clamp(mouseXPosition, minX, maxX);
            
        }
        else
        {
            paddlePosition.x = gameBall.transform.position.x;
        }

        transform.position = paddlePosition;

    }
}
