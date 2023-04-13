using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;
    public void OnClickCreateRoom()
   {
        if(roomName.text != "")
        {
            PhotonNetwork.CreateRoom(roomName.text);
        }
        
   }

    public void OnClickJoinRoom()
    {
        if (roomNameJoin.text != "")
        {
            PhotonNetwork.JoinRoom(roomNameJoin.text);
        }
            
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyRoom");
    }
}
