using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//TODO
public class LevelManager : MonoBehaviour
{
    private LevelManager ins;
    public LevelManager Instance
    {
        get
        {
            if (ins == null)
            {
                ins = FindObjectOfType<LevelManager>();

                if (ins == null)
                {
                    GameObject singleton = new GameObject(typeof(LevelManager).Name);
                    ins = singleton.AddComponent<LevelManager>();
                }
            }
            return ins;
        }
    }
    public TextAsset[] mapCSV;
    private int currentLevel = 0;
    int[,] levelInt;
    public GameObject brickPrefab;
    public GameObject wallPrefab;
    public GameObject brigdePrefab;
    public GameObject winPosition;
    public Transform levelTransform;
    void Awake()
    {
        LoadLevel(0);
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }
    }
    public void LoadLevel(int currentLevel)
    {
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
