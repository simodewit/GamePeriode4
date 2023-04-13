using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMultiplayer : MonoBehaviourPunCallbacks
{
    public TMP_Text loading;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(LoadingThis());
            
        }
            
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenu"); 
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
    }
    

 
}
