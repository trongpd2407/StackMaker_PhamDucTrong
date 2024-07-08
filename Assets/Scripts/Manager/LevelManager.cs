using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//TODO
public class LevelManager : Singleton<LevelManager>
{

    public TextAsset[] mapCSV;
    int[,] levelInt;
    public GameObject brickPrefab;
    public GameObject wallPrefab;
    public GameObject brigdePrefab;
    public GameObject winPosition;
    public Transform levelTransform;

    public void LoadLevel(int currentLevel)
    {
        foreach (Transform child in levelTransform)
        {
            Destroy(child.gameObject);
        }
        string[] line = mapCSV[currentLevel].text.Split('\n');
        int levelSize = line.Length;
        levelInt = new int[levelSize, levelSize];

        for(int i = 0; i < levelSize; i++)
        {
            string[] mapRow = line[i].Split(",");
           
            for(int j = 0; j < levelSize; j++)
            {
                int.TryParse(mapRow[j], out levelInt[i, j]);
            }
        }

        for(int i = 0;i < levelSize; i++)
        {
            for(int j = 0; j < levelSize; j++)
            {
                switch (levelInt[i,j])
                {
                    case Constant.WALL_NUMBER:
                        Instantiate(wallPrefab, new Vector3(i * 1, 0, j * 1), Quaternion.identity, levelTransform);
                        break;
                    case Constant.BRICK_NUMBER:
                        Instantiate(brickPrefab, new Vector3(i * 1, 0, j * 1), Quaternion.identity, levelTransform);
                        break;
                    case Constant.BRIGDE_NUMBER:
                        Instantiate(brigdePrefab, new Vector3(i * 1, 0, j * 1), Quaternion.identity, levelTransform);
                        break;
                    case Constant.WIN_NUMBER:
                        Instantiate(winPosition, new Vector3(i * 1, 0, j * 1), Quaternion.identity, levelTransform);
                        break;
                }
                
            }
        }
       
    }

}
