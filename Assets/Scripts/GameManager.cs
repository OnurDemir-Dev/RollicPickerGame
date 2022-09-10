using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    [SerializeField]
    GameObject StartScreen;

    public static int Level = 1;

    void Start()
    {
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
}
