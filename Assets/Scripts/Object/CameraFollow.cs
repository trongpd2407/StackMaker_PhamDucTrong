using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offset;

    
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
