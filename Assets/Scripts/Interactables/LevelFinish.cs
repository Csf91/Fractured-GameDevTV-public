using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    //scene 0 is tutorial scene
    [SerializeField] private int _indexSceneToLoad = 1;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // _player = GameObject.Find("Pino").GetComponent<PlayerController>();

        if (_gameManager == null) Debug.Log("Game Manager is NULL");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_indexSceneToLoad < 0)
            {
                PlayerController pc = other.GetComponent<PlayerController>();

                if (pc != null)
                {
                    pc.enabled = false;
                    
                    pc.PlayGongSFX();
                }
                
                _gameManager.SetGameOver();
            }
            else SceneManager.LoadScene(_indexSceneToLoad);
        }
    }
}