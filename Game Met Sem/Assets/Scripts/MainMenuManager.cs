using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject loadingAtStart;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public GameObject exitgame;
    public GameObject playOptions;
    public GameObject createAndJoin;
    public AudioSource soundEffect;
    public TMP_Text loading;
    private bool check;

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
        //joins game
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
        //creates lobby
    }

    public void OnClickJoin()
    {
        SoundEffectTrigger();
        createAndJoin.SetActive(false);
        //joins lobby
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
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        loadingAtStart.SetActive(false);
        mainMenu.SetActive(true);
    }
}
