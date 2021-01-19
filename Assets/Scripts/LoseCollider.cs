using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // Cached refs
    GameStatus gameStatus;
    [SerializeField] Ball gameBall;
    
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        gameBall = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameStatus.GetLives() > 0)
        {
            gameStatus.LoseLife();
            gameBall.Reset();
        }
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
