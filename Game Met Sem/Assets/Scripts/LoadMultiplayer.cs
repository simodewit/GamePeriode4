using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoadMultiplayer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

 
}
