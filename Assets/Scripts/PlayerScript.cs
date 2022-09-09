using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Touch touch;
    public float speed = 5.0f;
    public float horizontalspeed = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (GameManager.gameStatus == GameManager.GameStatus.start)
            {
                GameManager.gameStatus = GameManager.GameStatus.progress;
            }
        }
       
    }

    private void FixedUpdate()
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
                if(touch.phase == TouchPhase.Moved)
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
            transform.Translate(new Vector3(movevalue, 0.0f, speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StopPoint")
        {
            GameManager.gameStatus = GameManager.GameStatus.pause;
        }
    }
}
