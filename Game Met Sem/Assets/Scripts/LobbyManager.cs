using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject mainMenuManager;
    public TMP_Text playerCount;
    
    private void Start()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate("Player 2", transform.position, Quaternion.identity);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            PhotonNetwork.Instantiate("Player 3", transform.position, Quaternion.identity);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            PhotonNetwork.Instantiate("Player 4", transform.position, Quaternion.identity);
        }


        mainMenuManager = GameObject.Find("MaineMenuManager");

        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();

        


    }

}
