using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int bricksLeft = 0;
    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBrick()
    {
        bricksLeft++;
    }

    public void RemoveBrick()
    {
        bricksLeft--;
        if (bricksLeft == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }


}
