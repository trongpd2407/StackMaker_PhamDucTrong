using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigde : MonoBehaviour
{
    private bool isBuilt;

    [SerializeField] private MeshRenderer brickRenderer;
    private void Start()
    {
        brickRenderer.enabled = false;
    }
    public void EnableMesh()
    {
        if (!isBuilt)
        {
            brickRenderer.enabled = true;
            isBuilt = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            Player player = other.GetComponent<Player>();
            if(player == null || isBuilt)
            {
                return;
            }
            if (player.GetBrickCount() <= 0)
            {
                return ;
            }
            EnableMesh();
            player.DecreaseBrick();
        }
    }
}
