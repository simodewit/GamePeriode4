using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
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
}
