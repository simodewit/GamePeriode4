using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject Credits;
    public GameObject exitgame;
  public void OnClickPlay()
    {
        SceneManager.LoadScene("PlayOptions");
    }

    public void OnClickBackSettings()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
    public void OnClickSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void OnClickBackCredits()
    {
        mainMenu.SetActive(true);
        Credits.SetActive(false);
    }
    public void OnClickCredits()
    {
        mainMenu.SetActive(false);
        Credits.SetActive(true);
    }
    public void OnClickBackExitGame()
    {
        mainMenu.SetActive(true);
        exitgame.SetActive(false);
    }
    public void OnClickNoExitGame()
    {
        mainMenu.SetActive(false);
        exitgame.SetActive(true);
    }
    public void OnClickYesExitGame()
    {
       Application.Quit();
    }



}
