using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public GameObject mainMenuManager;
    
    private void Start()
    {
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
        mainMenuManager = GameObject.Find("MaineMenuManager");
    }

}
