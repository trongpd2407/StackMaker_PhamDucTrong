using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { MainMenu, GamePlay, Pause }
public class GameManger : Singleton<GameManger>
{
    public Player player;
    private int gameLevel;
    private GameState gameState;

    public GameState GameState { get => gameState; set => gameState = value; }
    void Awake()
    {
        gameLevel = 0;
        GameState = GameState.MainMenu;
        player.OnInIt();
        LevelManager.Instance.LoadLevel(gameLevel);

    }

    public void StartGame()
    {
        UIManager.Instance.ShowGamePlayUI(gameLevel+1);
        StartLevel();
    }

    public void StartLevel()
    {
        GameState = GameState.GamePlay;
    }

    public void WinLevel()
    {
        Debug.Log("Winn");
        UIManager.Instance.ShowWinUI();
    }

    //FIXME: Out out index max level 
    public void NextLevel()
    {   
        gameLevel++;
        player.OnInIt();
        LevelManager.Instance.LoadLevel(gameLevel);
        UIManager.Instance.ShowGamePlayUI(gameLevel+1);
    }
    public void RestartLevel()
    {
        player.OnInIt();
        LevelManager.Instance.LoadLevel(gameLevel);
        UIManager.Instance.ShowGamePlayUI(gameLevel + 1);
    }
}
