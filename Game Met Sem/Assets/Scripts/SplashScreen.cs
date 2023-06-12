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

    public void Start()
    {
        AudioListener.volume = 0.1f;
    }

    public void Update()
    {
        if (!Input.anyKey)
            return;

        if (check == true)
            return;

        check = true;
        buttonClickSound.Play();
        StartCoroutine("Loading");
    }

    public IEnumerator Loading()
    {
        //dit elke keer triggeren als hij nog niet is geconnect
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading...";
        yield return new WaitForSeconds(0.5f);


        //dit verwijderen
        text.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        //deze triggeren los van de IEnumerator
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();       
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
