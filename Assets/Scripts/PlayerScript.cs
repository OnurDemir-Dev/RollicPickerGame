﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Touch touch;
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float horizontalspeed = 0.001f;

    [SerializeField]
    private float maxhorizontalspeed = 0.1f;

    [SerializeField]
    private float maxXValue = 3.25f;


    void Start()
    {
        
    }

    void Update()
    {
        
       
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StopPoint")
        {
            GameManager.gameStatus = GameManager.GameStatus.pause;
            Destroy(other.gameObject);
        }
        if(other.tag == "LevelUp")
        {
            GameManager.Level++;
            GameManager.NewLevel++;
            Debug.Log(GameManager.NewLevel);
            Destroy(other.gameObject);
            GameObject instantlevel;
            if (GameManager.Level > GameManager.MaxLevel)
            {
                int randomlevel = UnityEngine.Random.Range(1, GameManager.MaxLevel);
                instantlevel = Resources.Load<GameObject>("Levels/Level" + randomlevel.ToString());
            }
            else
            {
                instantlevel  = Resources.Load<GameObject>("Levels/Level" + (GameManager.Level).ToString());
            }
            Destroy(GameManager.CurrentLevel);
            GameManager.CurrentLevel = GameObject.Instantiate(instantlevel, new Vector3(9.0f, 7.1f, -3.5f + (GameManager.NewLevel * 150.5f)), Quaternion.identity);
        }
    }

    private void PlayerMovement()
    {
        if (GameManager.gameStatus == GameManager.GameStatus.progress)
        {
            float movevalue = 0.0f;

            #region Mobile Code
            //If game play on mobile device
#if UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    movevalue = touch.deltaPosition.x * horizontalspeed;
                }

            }
#endif
            #endregion

            #region PC
#if UNITY_EDITOR
            if (Input.GetAxisRaw("Horizontal") != 0.0f)
            {
                movevalue = Input.GetAxisRaw("Horizontal") * maxhorizontalspeed;
            }
#endif 
            #endregion

            if ((transform.position.x + movevalue) >= maxXValue || (transform.position.x + movevalue) <= -maxXValue) movevalue = 0;
            movevalue = Mathf.Clamp(movevalue, -maxhorizontalspeed, maxhorizontalspeed);

            transform.Translate(new Vector3(movevalue, 0.0f, speed * Time.deltaTime));
        }
    }
}
