using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constant.TAG_PLAYER))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.NextLevel();
        }
    }
}
