using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int score = 0;
    [SerializeField] int ptsPerBrick = 33;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        score += ptsPerBrick;
        scoreText.text = score.ToString();

    }
}
