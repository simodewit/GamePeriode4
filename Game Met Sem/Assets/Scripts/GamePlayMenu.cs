using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMenu : MonoBehaviour
{
    #region variables

    //uiPresets
    public GameObject escapeMenu;
    public GameObject escapeSettings;
    public GameObject escapeBackToMenu;
    public GameObject escapeQuitGame;

    //sounds
    public AudioSource buttonClickSound;

    #endregion

    #region button functions

    public void Update()
    {
        if(!Input.GetKeyDown(KeyCode.Escape))
            return;

        //go step back
    }

    public void EscapeMenu()
    {
        ButtonPressSound();
        escapeMenu.SetActive(true);
    }

    public void EscapeResumeToGame()
    {
        ButtonPressSound();
        escapeMenu.SetActive(false);
    }

    public void EscapeSettings()
    {
        ButtonPressSound();
        escapeMenu.SetActive(false);
        escapeSettings.SetActive(true);
    }

    public void EscapeSettingsBack()
    {
        ButtonPressSound();
        escapeSettings.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeBackToMenu()
    {
        ButtonPressSound();
        escapeMenu.SetActive(false);
        escapeBackToMenu.SetActive(true);
    }

    public void EscapeBackToMenuNo()
    {
        ButtonPressSound();
        escapeBackToMenu.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeBackToMenuYes()
    {
        ButtonPressSound();
        escapeBackToMenu.SetActive(false);
        //loadingScreen
        SceneManager.LoadScene("MainMenu");
    }

    public void EscapeQuitGame()
    {
        ButtonPressSound();
        escapeMenu.SetActive(false);
        escapeQuitGame.SetActive(true);
    }

    public void EscapeQuitGameNo()
    {
        ButtonPressSound();
        escapeQuitGame.SetActive(false);
        escapeMenu.SetActive(true);
    }

    public void EscapeQuitGameYes()
    {
        ButtonPressSound();
        Application.Quit();
    }

    #endregion

    #region extra effects

    public void ButtonPressSound()
    {
        if(!buttonClickSound.enabled)
        {
            buttonClickSound.enabled = true;
        }
        else
        {
            buttonClickSound.Play();
        }
    }

    #endregion
}
