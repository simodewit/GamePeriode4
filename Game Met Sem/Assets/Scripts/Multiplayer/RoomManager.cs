using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomName;
    public TMP_InputField roomNameJoin;
    public void OnClickCreateRoom()
   {
        if(roomName.text != "")
        {
            if (roomName.text.Length <= 10)
            {
                PhotonNetwork.CreateRoom(roomName.text);
            }
               
        }
        
   }

    public void OnClickJoinRoom()
    {
        if (roomNameJoin.text != "")
        {
            if (roomNameJoin.text.Length <= 10)
            {
                PhotonNetwork.JoinRoom(roomNameJoin.text);
            }
                
        }
            
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("TestPickUp");
    }

    public void OnClickBack()
    {

        SceneManager.LoadScene("PlayOptions");
    }
}
