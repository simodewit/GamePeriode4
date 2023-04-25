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
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public GameObject exitgame;
    public GameObject playOptions;
    public GameObject createAndJoin;

    public GameObject escapeMenu;
    public GameObject escOptions;
    public GameObject escBackToMenu;
    public GameObject escQuitGame;

    public AudioSource soundEffect;
    public TMP_Text loading;
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;
    public Slider volumeSlider;
    public MusicManager manager;

    private bool check;
    private bool check2;
    private bool check3;
    private bool check4;
    private int randomNumber;
    public string randomName;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Update()
    {

        if(check == false)
        {
            if(Input.anyKey)
            {
                check = true;
                SoundEffectTrigger();
                StartCoroutine(LoadingThis());
            }
        }

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OnClickEscape();
            }
        }

        OptionsManager();
    }







    public void OnClickPlay()
    {
        SoundEffectTrigger();
        mainMenu.SetActive(false);
        playOptions.SetActive(true);
    }

    public void OnClickSinglePlayer()
    {
        SoundEffectTrigger();
        playOptions.SetActive(false);
        loadingScreen.SetActive(true);

        randomNumber = Random.Range(100000, 999999);
        randomName = randomNumber.ToString();

        PhotonNetwork.CreateRoom(randomName);
    }

    public void OnClickMultiplayer()
    {
        SoundEffectTrigger();
        playOptions.SetActive(false);
        createAndJoin.SetActive(true);
    }

    public void OnClickCreate()
    {
        SoundEffectTrigger();

        if (roomName.text != "")
        {
            if (roomName.text.Length <= 10)
            {
                createAndJoin.SetActive(false);
                loadingScreen.SetActive(true);
                check3 = true;
                StartCoroutine(LoadingThis());
            }
        }
    }

    public void OnClickJoin()
    {
        SoundEffectTrigger();

        if (roomNameJoin.text != "")
        {
            createAndJoin.SetActive(false);
            loadingScreen.SetActive(true);
            check3 = false;
            StartCoroutine(LoadingThis());
        }
    }

    public void OnClickSettings()
    {
        SoundEffectTrigger();
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OnClickCredits()
    {
        SoundEffectTrigger();
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void OnClickExitGame()
    {
        SoundEffectTrigger();
        mainMenu.SetActive(false);
        exitgame.SetActive(true);
    }

    public void OnClickNoExitGame()
    {
        SoundEffectTrigger();
        exitgame.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickYesExitGame()
    {
        SoundEffectTrigger();
        Application.Quit();
    }

    public void OnClickBackSettings()
    {
        SoundEffectTrigger();
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void OnClickBackCredits()
    {
        SoundEffectTrigger();
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickBackPlayOptions()
    {
        SoundEffectTrigger();
        playOptions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnClickBackCreateAndJoin()
    {
        SoundEffectTrigger();
        createAndJoin.SetActive(false);
        playOptions.SetActive(true);
    }








    public void SoundEffectTrigger()
    {
        if(soundEffect.enabled == false)
        {
            soundEffect.enabled = true;
        }
        else
        {
            soundEffect.Play();
        }
    }

    public IEnumerator LoadingThis()
    {
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);

        if(check2 == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinLobby();
            PhotonNetwork.AutomaticallySyncScene = true;
            mainMenu.SetActive(true);
            check2 = true;
        }
        else
        {
            if(check3 == true)
            {
                check3 = false;
                PhotonNetwork.CreateRoom(roomName.text);
            }
            else
            {
                PhotonNetwork.JoinRoom(roomNameJoin.text);
            }

            if(check4 == true)
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("MainMenu");
                mainMenu.SetActive(true);
                manager.leave = true;
            }
        }

        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        loadingScreen.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");
    }

    public void OptionsManager()
    {
        AudioListener.volume = volumeSlider.value;
    }








    public void OnClickEscape()
    {
        SoundEffectTrigger();
        escapeMenu.SetActive(true);
    }

    public void OnClickEscResume()
    {
        SoundEffectTrigger();
        escapeMenu.SetActive(false);
    }

    public void OnClickEscOptions()
    {
        SoundEffectTrigger();
        escOptions.SetActive(true);
        escapeMenu.SetActive(false);
    }

    public void OnClickEscExitToMenu()
    {
        SoundEffectTrigger();
        escBackToMenu.SetActive(true);
        escapeMenu.SetActive(false);
    }

    public void OnClickEscYesToMenu()
    {
        SoundEffectTrigger();
        check4 = true;
        escBackToMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadingThis());
    }

    public void OnClickEscNoToMenu()
    {
        escapeMenu.SetActive(true);
        escBackToMenu.SetActive(false);
    }

    public void OnClickEscQuitGame()
    {
        SoundEffectTrigger();
        escQuitGame.SetActive(true);
        escapeMenu.SetActive(false);
    }

    public void OnClickEscYesQuitGame()
    {
        SoundEffectTrigger();
        Application.Quit();
    }

    public void OnClickEscNoQuitGame()
    {
        SoundEffectTrigger();
        escapeMenu.SetActive(true);
        escQuitGame.SetActive(false);
    }

    public void OnClickEscBackOptions()
    {
        SoundEffectTrigger();
        escOptions.SetActive(false);
        escapeMenu.SetActive(true);
    }
}
