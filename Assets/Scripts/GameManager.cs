using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    [SerializeField]
    GameObject StartScreen;

    [SerializeField]
    GameObject GameOverScreen;

    [SerializeField]
    Text pointtext;
    #endregion

    public int CurrentLevelPoint = 0;

    public static int MaxLevel = 2;
    public static int Level = 1;
    public static int NewLevel = 0;

    public static GameObject CurrentLevel;

    void Start()
    {
        GameManager.CurrentLevel = Resources.Load<GameObject>("Levels/Level" + Level.ToString());
        if (!GameManager.CurrentLevel)
        {
             
        }
        GameManager.CurrentLevel = GameObject.Instantiate(GameManager.CurrentLevel, new Vector3(9.0f, 7.1f, -3.5f), Quaternion.identity);
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

    public void AddPoint()
    {
        CurrentLevelPoint++;
        pointtext.text = CurrentLevelPoint.ToString();
    }
}
