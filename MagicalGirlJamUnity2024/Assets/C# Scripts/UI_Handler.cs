using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;
    public GameObject settingsUI;
    void Start()
    {
        GameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeESC();
            }
            else
            {
                Pause();
            }
        }
    }

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

    public void ResumeClick()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void ResumeESC()
    {
        pauseUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
