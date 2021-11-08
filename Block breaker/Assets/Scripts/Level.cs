using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //config params
    [SerializeField] int breakableBlocks;

    //cached referance
    SceneLoader sceneLoader;
    GameStatus gameStatus;

    //game
    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void whenBlockDestroyed()
    {
        breakableBlocks--;
        gameStatus.AddScore();
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
