using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField]
    Color fogcolor;

    void Start()
    {
        RenderSettings.fogColor = fogcolor;
    }

}
