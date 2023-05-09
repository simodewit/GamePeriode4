using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviourPunCallbacks
{
    #region variables

    //ui presets
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public GameObject exitgame;
    public GameObject playOptions;
    public GameObject createAndJoin;

    //soundeffects
    public AudioSource ButtonClickSound;

    //loadingScreen
    public TMP_Text loading;
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;

    //options
    public Slider volumeSlider;
    public TMP_Dropdown resolutions;
    public Toggle fullscreen;
    public int width;
    public int height;

    //random name generator
    private int randomNumber;
    public string randomName;

    #endregion

    #region update

    public void Update()
    {
        OptionsManager();
    }

    #endregion

    #region button functions

    public void OnClickPlay()
    {
        ButtonClickSound.Play();
        mainMenu.SetActive(false);
        playOptions.SetActive(true);
    }

    public void OnClickSinglePlayer()
    {
        ButtonClickSound.Play();
        playOptions.SetActive(false);
        loadingScreen.SetActive(true);

        randomNumber = Random.Range(100000, 999999);
        randomName = randomNumber.ToString();

        StartCoroutine(LoadingThis());

        PhotonNetwork.CreateRoom(randomName);
    }

    public void OnClickMultiplayer()
    {
        ButtonClickSound.Play();
        playOptions.SetActive(false);
        createAndJoin.SetActive(true);
    }

    public void OnClickCreate()
    {
        ButtonClickSound.Play();

        if (roomName.text != "")
            return;

        if (roomName.text.Length <= 10)
            return;

        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadingThis());
    }

    public void OnClickJoin()
    {
        ButtonClickSound.Play();

        if (roomNameJoin.text != "")
            return;

        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadingThis());
    }

    public void OnClickSettings()
    {
        ButtonClickSound.Play();
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OnClickCredits()
    {
        ButtonClickSound.Play();
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void OnClickExitGame()
    {
        ButtonClickSound.Play();
        mainMenu.SetActive(false);
        exitgame.SetActive(true);
    }

    public void OnClickNoExitGame()
    {
        ButtonClickSound.Play();
        exitgame.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickYesExitGame()
    {
        ButtonClickSound.Play();
        Application.Quit();
    }

    public void OnClickBackSettings()
    {
        ButtonClickSound.Play();
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void OnClickBackCredits()
    {
        ButtonClickSound.Play();
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickBackPlayOptions()
    {
        ButtonClickSound.Play();
        playOptions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickBackCreateAndJoin()
    {
        ButtonClickSound.Play();
        createAndJoin.SetActive(false);
        playOptions.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");
    }

    #endregion

    #region options

    public void OptionsManager()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void OnClickApplyButton()
    {
        Screen.SetResolution(width, height, fullscreen.isOn);
    }

    #endregion

    #region loadingScreen

    public IEnumerator LoadingThis()
    {
        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        loadingScreen.SetActive(false);
    }

    #endregion
}
