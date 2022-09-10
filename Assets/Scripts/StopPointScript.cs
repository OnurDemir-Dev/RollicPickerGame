using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopPointScript : MonoBehaviour
{
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
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PushObject")
        {
            if (!alreadyrun) StartCoroutine(StartCount());
            CurrentValue++;
            CountText.text = CurrentValue.ToString() + "/" + MaxValue.ToString();
        }
    }

    private IEnumerator StartCount()
    {
        alreadyrun = true;
        yield return new WaitForSeconds(3);
        if(CurrentValue >= MaxValue)
        {
            Debug.Log("Complete");
            GameManager.gameStatus = GameManager.GameStatus.progress;
        }
        else
        {
            Debug.Log("Not Complete");
        }
    }
}
