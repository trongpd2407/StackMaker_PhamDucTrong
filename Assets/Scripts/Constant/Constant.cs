using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant 
{
    //TAG
    public const string TAG_BRICK = "Brick";
    public const string TAG_PLAYER = "Player";

    //RaycastLength
    public const float CHECK_BRICK_LENGTH = 0.6f;

    public const float MAX_DISTANCE = 1f;


    //Directions
    public static readonly Quaternion RIGHT_DIRECTION = Quaternion.Euler(0, 90, 0);
    public static readonly Quaternion LEFT_DIRECTION = Quaternion.Euler(0, -90, 0);
    public static readonly Quaternion FORWARD_DIRECTION = Quaternion.Euler(0, 0, 0);
    public static readonly Quaternion BACK_DIRECTION = Quaternion.Euler(0, 180, 0);

    public static Vector3 BRICK_HEIGHT = new Vector3(0, 0.3f, 0);

    public static Vector3 VISUAL_OFFSET = new Vector3(0, 0.15f, 0);

    public const float WIN_DISTANCE = 7f;

    //Numbers for draw map from csv
    public const int WALL_NUMBER = 1;
    public const int BRICK_NUMBER = 2;
    public const int BRIGDE_NUMBER = 3;
    public const int WIN_NUMBER = 4;
}
