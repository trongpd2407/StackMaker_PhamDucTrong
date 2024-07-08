using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triiger");
        if(other.CompareTag(Constant.TAG_PLAYER))
        {
            Debug.Log("plauer");
          
        }
    }
}
