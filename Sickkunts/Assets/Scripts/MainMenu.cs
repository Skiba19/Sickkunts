using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level1ToLoad="Level_1";
    public void Play()
    {
        SceneManager.LoadScene(level1ToLoad);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
