using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform beginPos;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private Transform playerVisualTransform;

    [SerializeField] private Transform checkPosTransform;

    [SerializeField] private LayerMask brickLayer;

    [SerializeField] private GameObject brickPrefab;

    
    private Stack<GameObject> stackBrick;

    private Vector2 startSwipePos;
    private Vector2 endSwipePos;
    private Vector2 swipeDirection;
    private Vector3 target;

    private bool isMoving;

    public void OnInIt()
    {
    }
    void Start()
    {
        playerTransform.position = beginPos.position;
        stackBrick = new Stack<GameObject>();
        stackBrick.Clear();
    }
    private void Update()
    {
        ChangeDirection();
    }

    void FixedUpdate()
    {

        Move();
    }


    private void ChangeDirection()
    {
        if (isMoving)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            startSwipePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endSwipePos = Input.mousePosition;
        }
        swipeDirection = endSwipePos - startSwipePos;

        if (Mathf.Abs(swipeDirection.x) < 0.001f && Mathf.Abs(swipeDirection.y) < 0.001f)
        {
            return;
        }
        if ((Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y)) )
        {
            if (swipeDirection.x > 0)
            {
                checkPosTransform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                checkPosTransform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else
        {
            if (swipeDirection.y > 0)
            {
                checkPosTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                checkPosTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
    }
    private void Move()
    {
        if (Mathf.Abs(swipeDirection.x) < 0.001f && Mathf.Abs(swipeDirection.y) < 0.001f)
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(checkPosTransform.position, checkPosTransform.forward, out hit, Constant.CHECK_BRICK_LENGTH, brickLayer))
        {
            isMoving = true;
            target = hit.transform.position + new Vector3(0, 2.5f, 0);
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, target, Constant.PLAYER_SPEED * Time.deltaTime);

        }
        else
        {
            isMoving = false;
        }
     
    }




    public void IncreaseBrick()
    {
        Vector3 newBrickPos = playerTransform.position + Constant.BRICK_HEIGHT * stackBrick.Count;
        GameObject newBrick = Instantiate(brickPrefab, newBrickPos, brickPrefab.transform.rotation, playerTransform);
        stackBrick.Push(newBrick);
        playerVisualTransform.position = playerTransform.position + Constant.VISUAL_OFFSET + Constant.BRICK_HEIGHT * stackBrick.Count;
     
    }


    public void DecreaseBrick()
    {
        Destroy(stackBrick.Pop());
        playerVisualTransform.position -= Constant.BRICK_HEIGHT;
    }
    


}

