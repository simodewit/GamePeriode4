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
    public AudioSource soundEffect;

    //loadingScreen
    public TMP_Text loading;
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;

    //options
    public Slider volumeSlider;

    //random name generator
    private int randomNumber;
    public string randomName;

    #endregion

    #region button functions

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

        StartCoroutine(LoadingThis());

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
            return;

        if (roomName.text.Length <= 10)
            return;

        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadingThis());
    }

    public void OnClickJoin()
    {
        SoundEffectTrigger();

        if (roomNameJoin.text != "")
            return;

        createAndJoin.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadingThis());
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

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");
    }

    public void OptionsManager()
    {
        AudioListener.volume = volumeSlider.value;
    }

    #endregion

    #region extra effects

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
