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
    public GameObject manager;

    public void Start()
    {
        manager = GameObject.Find("MainMusicManager");
    }

    public void OnClickCreateRoom()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        if (roomName.text != "")
        {
            if (roomName.text.Length <= 10)
            {
                PhotonNetwork.CreateRoom(roomName.text);
            }
               
        }
        
    }

    public void OnClickJoinRoom()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
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
        PhotonNetwork.LoadLevel("LobbyRoom");
    }

    public void OnClickBack()
    {
        manager.GetComponent<MusicManager>().SoundEffect();
        SceneManager.LoadScene("PlayOptions");
    }
}
