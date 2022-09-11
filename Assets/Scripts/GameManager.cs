﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        undefined,
        progress,
        pause,
        start
    }

    public static GameStatus gameStatus = GameStatus.start;

    #region UIVariables
    [Header("UI Variables")]
    [SerializeField]
    public GameObject StartScreen;

    [SerializeField]
    public GameObject LevelCompleteScreen;

    [SerializeField]
    GameObject GameOverScreen;

    [Header("UI Text")]
    [SerializeField]
    Text pointtext;

    [SerializeField]
    Text leveltext;
    #endregion

    public static int MaxLevel = 4;
    public static int Level = 1;
    public static int NewLevel = 0;

    public static GameObject FirstLevel;
    public static GameObject LastLevel; 

    void Start()
    {
        DOTween.Init();
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        GameManager.Level = PlayerPrefs.GetInt("Level");
        ChangeLevelText();

        GameObject instantlevel;
        if (GameManager.Level > GameManager.MaxLevel)
        {
            int randomlevel = UnityEngine.Random.Range(1, GameManager.MaxLevel + 1);
            instantlevel = Resources.Load<GameObject>("Levels/Level" + randomlevel.ToString());
        }
        else
        {
            instantlevel = Resources.Load<GameObject>("Levels/Level" + (GameManager.Level).ToString());
        }
        GameManager.FirstLevel = GameObject.Instantiate(instantlevel, new Vector3(9.0f, 7.1f, -3.5f), Quaternion.identity);
        gameStatus = GameStatus.start;
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (GameManager.gameStatus == GameManager.GameStatus.start)
            {
                GameManager.gameStatus = GameManager.GameStatus.progress;
                StartScreen.gameObject.SetActive(false);
            }
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ChangeLevelText()
    {
        leveltext.text = GameManager.Level.ToString();
    }

    public void LevelCompleteScreenButton()
    {
        GameManager.gameStatus = GameStatus.start;
        LevelCompleteScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}
