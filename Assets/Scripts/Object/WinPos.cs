using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] private GameObject openChest;
    [SerializeField] private GameObject closeChest;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constant.TAG_PLAYER))
        {
            openChest.SetActive(true);
            closeChest.SetActive(false);
        }
    }
}
