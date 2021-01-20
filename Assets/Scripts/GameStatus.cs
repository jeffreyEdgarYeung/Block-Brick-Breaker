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
    [SerializeField] int lives = 4;
    [SerializeField] GameObject lifeSprite;
    [SerializeField] int maxScoreLength = 4;
    [SerializeField] AudioClip[] lifeSounds;

    AudioSource gameAudioSource;

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
        gameAudioSource = GetComponent<AudioSource>(); 
        scoreText.text = GetScoreString();
        RenderLives();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void AddToScore()
    {
        int prevScore = score;

        score += ptsPerBrick;
        
        if(score/1000 != prevScore / 1000)
        {
            GainLife();
        }
        scoreText.text = GetScoreString();

    }

    private string GetScoreString()
    {
        int numZeros = maxScoreLength - score.ToString().Length;

        string sText = "Score: ";

        for (int i = 0; i < numZeros; i++)
        {
            sText += "0";
        }
        return sText + score.ToString();
    }

    public void reset()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return autoPlay;
    }

    public void LoseLife()
    {
        lives--;
        gameAudioSource.PlayOneShot(lifeSounds[0]);
        RenderLives();
    }

    public void GainLife()
    {
        lives++;
        gameAudioSource.PlayOneShot(lifeSounds[1], 0.5f);
        RenderLives();
    }

    public int GetLives()
    {
        return lives;
    }

    private void RenderLives()
    {
        GameObject[] currLives = GameObject.FindGameObjectsWithTag("Life");
        foreach(GameObject life in currLives)
        {
            Destroy(life);
        }
        for( int i = 0; i < lives; i++)
        {
            Vector3 lifeSpitePos = new Vector3((i *.75f + 0.25f), 12.75f, 0);
            Instantiate(lifeSprite, lifeSpitePos, Quaternion.identity);
        }
    }
}
