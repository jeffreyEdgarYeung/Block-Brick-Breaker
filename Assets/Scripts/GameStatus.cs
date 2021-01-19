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
    [SerializeField] bool autoPlay = false;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void reset()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return autoPlay;
    }
}
