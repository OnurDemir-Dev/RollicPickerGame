using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    void Start()
    {
        gameStatus = GameStatus.start;
    }

    void Update()
    {
        
    }
}
