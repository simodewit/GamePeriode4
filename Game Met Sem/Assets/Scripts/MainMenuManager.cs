using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject playMenu;

    public void OnClickPlay()
    {
        menuPanel.SetActive(false);
        playMenu.SetActive(true);
    }
    public void OnClickBack()
    {
        menuPanel.SetActive(true);
        playMenu.SetActive(false);
    }

    public void OnClickMultiplayer()
    {
        SceneManager.LoadScene("JoinLobby");
    }

    public void OnClickSingleplayer()
    {

    }
}
