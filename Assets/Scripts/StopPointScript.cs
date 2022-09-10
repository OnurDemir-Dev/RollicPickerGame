using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopPointScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] levels;

    GameManager gameManager;

    [SerializeField]
    private int MaxValue;

    [SerializeField]
    private int CurrentValue;

    [SerializeField]
    TextMeshPro CountText;

    bool alreadyrun = false;

    void Start()
    {
        CountText.text = CurrentValue.ToString() + "/" + MaxValue.ToString();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PushObject")
        {

            CurrentValue++;
            CountText.text = CurrentValue.ToString() + "/" + MaxValue.ToString();
        }
        if (other.tag == "Player")
        {
            if (!alreadyrun) StartCoroutine(StartCount());
        }
    }

    private IEnumerator StartCount()
    {
        alreadyrun = true;
        yield return new WaitForSeconds(2);
        if(CurrentValue >= MaxValue)
        {
            Debug.Log("Complete");
            GameManager.gameStatus = GameManager.GameStatus.progress;
            gameManager.AddPoint();
        }
        else
        {
            Debug.Log("Not Complete");
            gameManager.GameOver();
        }
    }
}
