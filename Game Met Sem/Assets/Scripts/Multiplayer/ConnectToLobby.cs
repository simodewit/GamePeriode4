using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToLobby : MonoBehaviourPunCallbacks
{
    public TMP_InputField playerName;
    public TMP_Text buttonName;
   public void OnClickConnect()
    {
        PhotonNetwork.ConnectUsingSettings();
        buttonName.text = "Connecting...";


    }

}
