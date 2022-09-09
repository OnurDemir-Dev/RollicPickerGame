using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private float distanceY;

    [SerializeField]
    private float distanceZ;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(0, playerObject.transform.position.y + distanceY, playerObject.transform.position.z + distanceZ);
    }
}
