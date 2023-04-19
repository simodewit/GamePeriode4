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
    public GameObject manager;

    public void Start()
    {
        manager = GameObject.Find("MainMusicManager");
    }

    public void OnClickPlay()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        SceneManager.LoadScene("PlayOptions");
    }

    public void OnClickBackSettings()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickBackCredits()
    {
        mainMenu.SetActive(true);
        Credits.SetActive(false);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickCredits()
    {
        mainMenu.SetActive(false);
        Credits.SetActive(true);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickBackExitGame()
    {
        mainMenu.SetActive(true);
        exitgame.SetActive(false);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickNoExitGame()
    {
        mainMenu.SetActive(false);
        exitgame.SetActive(true);
        manager.GetComponent<MusicManager>().SoundEffect();
    }
    public void OnClickYesExitGame()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        Application.Quit();
    }



}
