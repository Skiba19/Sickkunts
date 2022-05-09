using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
    void OnEnable()
    {
        pointsText.text=PlayerStats.Points.ToString();
    }
    public void Retry()
    {
        WaveSpawner.EnemiesAlive=0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        WaveSpawner.EnemiesAlive=0;
        SceneManager.LoadScene("MainMenu");
    }
}
