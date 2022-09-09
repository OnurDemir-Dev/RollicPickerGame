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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PushObject")
        {
            CurrentValue++;
            CountText.text = CurrentValue.ToString() + "/" + MaxValue.ToString();
        }
    }
}
