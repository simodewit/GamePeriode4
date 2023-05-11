using JetBrains.Annotations;
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

    //random name generator
    private int randomNumber;
    public string randomName;

    //checks for looking what loadingscreen
    public bool multiplayerCreate;
    public bool multiplayerJoin;
    public bool singleplayer;

    #endregion

    #region update/start

    public void Start()
    {
        OnClickApplyButton();
    }

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

        singleplayer = true;
        StartCoroutine(LoadingThis());
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
        multiplayerCreate = true;
        StartCoroutine(LoadingThis());
    }

    public void OnClickJoin()
    {
        ButtonClickSound.Play();

        if (roomNameJoin.text != "")
            return;

        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);
        multiplayerJoin = true;
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
        SpecificJoinCode();
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        loadingScreen.SetActive(false);
    }

    public void SpecificJoinCode()
    {
        if (multiplayerCreate)
        {
            if(roomName.text != "")
            {
                PhotonNetwork.CreateRoom(roomName.text);
            }
            multiplayerCreate = false;
        }

        if (multiplayerJoin)
        {
            if (roomNameJoin.text != "")
            {
                PhotonNetwork.JoinRoom(roomNameJoin.text);
            }
            multiplayerJoin = false;
        }

        if(singleplayer)
        {
            PhotonNetwork.CreateRoom(randomName);
            singleplayer = false;
        }
    }

    #endregion

    #region options

    public ResolutionList[] res;

    public void OptionsManager()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void OnClickApplyButton()
    {
        Screen.SetResolution(res[resolutions.value].width, res[resolutions.value].height, fullscreen.isOn);
    }
}

[System.Serializable]
public class ResolutionList
{
    public int width;
    public int height;
}

#endregion
