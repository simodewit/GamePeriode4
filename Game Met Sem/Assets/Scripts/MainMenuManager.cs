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
    public AudioSource soundEffect;
    public TMP_Text loading;
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;
    private bool check;
    private bool check2;
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
        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);

        if (roomName.text != "")
        {
            if (roomName.text.Length <= 10)
            {
                PhotonNetwork.CreateRoom(roomName.text);
            }
        }
    }

    public void OnClickJoin()
    {
        SoundEffectTrigger();
        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);

        if (roomNameJoin.text != "")
        {
            PhotonNetwork.JoinRoom(roomNameJoin.text);
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
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        if(check2 == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinLobby();
            PhotonNetwork.AutomaticallySyncScene = true;
            loadingScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            loadingScreen.SetActive(false);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");
    }
}
