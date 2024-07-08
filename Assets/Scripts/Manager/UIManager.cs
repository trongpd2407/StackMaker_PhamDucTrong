using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//TODO
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject finish;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private TMP_Text level;



    public void ShowWinUI()
    {
        finish.SetActive(true);
    }
    public void ShowGamePlayUI(int currentLevel)
    {
        gamePlay.SetActive(true);
        mainMenu.SetActive(false);
        finish.SetActive(false);
        SetLevel(currentLevel);
       
    }
    public void SetLevel(int currentLevel)
    {
        level.text = "Level : " + currentLevel.ToString();
    }
}
