using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform targetPlayer;
    [SerializeField] private Vector3 cameraOffset;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = targetPlayer.position - cameraOffset;
    }
}
