using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StopPointScript : MonoBehaviour
{
    [SerializeField]
    GameObject objects;

    [SerializeField]
    GameObject elevatorfloor;

    [SerializeField]
    ParticleSystem partyparticle;

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
            partyparticle.Play();
            elevatorfloor.transform.DOLocalMoveY(0.72f, 1.0f).OnComplete(() =>
            {
                GameManager.gameStatus = GameManager.GameStatus.progress;
            });
        }
        else
        {
            Debug.Log("Not Complete");
            gameManager.GameOver();
        }
        objects.transform.DOScale(0, 2.0f).OnComplete(() => Destroy(objects));
    }
}
