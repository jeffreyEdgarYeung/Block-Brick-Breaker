using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1.23f;
    [SerializeField] float maxX = 14.76f;

    // Update is called once per frame
    void Update()
    {
        float mouseXPosition = (Input.mousePosition.x / Screen.width * screenWidthUnits);
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseXPosition, minX, maxX);
        transform.position = paddlePosition;
    }
}
