using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    GameManager _gameManager;


    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();

    }
    public void ReloadLevel()
    {
        if (_gameManager.isDead)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

