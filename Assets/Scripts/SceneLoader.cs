using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIdx + 1);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.reset();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
