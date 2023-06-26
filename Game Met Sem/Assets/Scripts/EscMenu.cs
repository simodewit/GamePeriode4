using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject settings;


    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        escMenu.SetActive(false);
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void MaineMneu()
    {
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.LeaveRoom();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }
}
