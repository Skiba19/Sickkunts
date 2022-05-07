using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded=false;
    void Update()
    {
        if(gameEnded==true)
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
        gameEnded=true;
    }
}
