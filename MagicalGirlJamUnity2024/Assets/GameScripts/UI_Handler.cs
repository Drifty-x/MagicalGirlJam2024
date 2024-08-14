using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public void LevelSelect1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void LevelSelect2()
    {
        SceneManager.LoadScene("Stage2");
    }

        public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
