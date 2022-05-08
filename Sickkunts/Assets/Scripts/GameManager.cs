using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    void Start()
    {
        GameIsOver=false;
    }
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            EndGame();
        }
        if(GameIsOver==true)
        {
            return;
        }
        if(PlayerStats.Lives<=0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        GameIsOver=true;
        gameOverUI.SetActive(true);
    }
}
