using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMenu : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject escapeSettings;
    public GameObject escapeBackToMenu;
    public GameObject escapeQuitGame;

    public void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Escape))
            return;

        //go step back
    }

    public void EscapeMenu()
    {
        //soundEffect
        escapeMenu.SetActive(true);
    }

    public void EscapeResumeToGame()
    {
        //soundeffect
        escapeMenu.SetActive(false);
    }

    public void EscapeSettings()
    {
        //soundEffect
        escapeMenu.SetActive(false);
        escapeSettings.SetActive(true);
    }

    public void EscapeSettingsBack()
    {
        //soundEffect
        escapeSettings.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeBackToMenu()
    {
        //soundEffect
        escapeMenu.SetActive(false);
        escapeBackToMenu.SetActive(true);
    }

    public void EscapeBackToMenuNo()
    {
        //soundEffect
        escapeBackToMenu.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeBackToMenuYes()
    {
        //soundEffect
        escapeBackToMenu.SetActive(false);
        //loadingScreen
        SceneManager.LoadScene("MainMenu");
    }

    public void EscapeQuitGame()
    {
        //soundEffect
        escapeMenu.SetActive(false);
        escapeQuitGame.SetActive(true);
    }

    public void EscapeQuitGameNo()
    {
        //soundEffect
        escapeQuitGame.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeQuitGameYes()
    {
        //soundEffect
        Application.Quit();
    }
}
