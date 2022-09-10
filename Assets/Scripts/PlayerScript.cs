using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Touch touch;
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float horizontalspeed = 0.5f;

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
                movevalue = Input.GetAxisRaw("Horizontal") * horizontalspeed;
            }
#endif 
            #endregion

            if ((transform.position.x + movevalue) >= maxXValue || (transform.position.x + movevalue) <= -maxXValue) movevalue = 0;

            transform.Translate(new Vector3(movevalue, 0.0f, speed * Time.deltaTime));
        }
    }
}
