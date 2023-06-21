using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviourPunCallbacks
{
    public TMP_Text text;
    public AudioSource buttonClickSound;
    public bool check;
    public bool isConnected;
    public bool isLoading;

    public void Start()
    {
        AudioListener.volume = 0.1f;
    }

    public void Update()
    {
        if (check == true)
        {
            if(isConnected == false)
            {
                if(isLoading == false)
                {
                    StartCoroutine("Loading");
                    isLoading = true;
                }
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (!Input.anyKey)
            return;

        if(check == true)
            return;

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        check = true;
        buttonClickSound.Play();

    }

    public IEnumerator Loading()
    {
        if(text.text == "Loading.")
        {
            text.text = "Loading..";
            yield return new WaitForSeconds(0.5f);
            isLoading = false;
        }
        if (text.text == "Loading..")
        {
            text.text = "Loading...";
            yield return new WaitForSeconds(0.5f);
            isLoading = false;
        }
        if (text.text == "Loading...")
        {
            text.text = "Loading.";
            yield return new WaitForSeconds(0.5f);
            isLoading = false;
        }    
    }

    public override void OnConnectedToMaster()
    {
        isConnected = true;
    }
}
