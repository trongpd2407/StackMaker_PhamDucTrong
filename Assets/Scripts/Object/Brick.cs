using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer brickRenderer;

   
    private bool isCollected;
    public bool IsCollected
    {
        get
        {
            return isCollected;
        }
            
    }
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) {
            DisableMesh();
        }
    }
    public void DisableMesh()
    {
        if (!IsCollected)
        {
            brickRenderer.enabled = false;
            isCollected = true;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        { 
            Player player = other.transform.GetComponent<Player>();
            if (isCollected || player == null)
            {
                return;
            }
            DisableMesh();
            player.IncreaseBrick();



        }
    }


}
