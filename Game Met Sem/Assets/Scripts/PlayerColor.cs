using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Material player1;
    public Material player2;
    public Material player3;
    public Material player4;
    public PhotonView view;
    public GameObject spawningPlayer;
    void Start()
    {
        if(!view.IsMine)
            return;

        view = GetComponent<PhotonView>();
        spawningPlayer = GameObject.Find("LobbyManager").GetComponent<SpawningPlayer>().player;

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            view.RPC("ChangeColor1", RpcTarget.All);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            view.RPC("ChangeColor2", RpcTarget.All);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
            view.RPC("ChangeColor3", RpcTarget.All);

        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            view.RPC("ChangeColor4", RpcTarget.All);
    }

    [PunRPC]
    public void ChangeColor1()
    {
        spawningPlayer.GetComponent<Renderer>().material = player1;
    }

    [PunRPC]
    public void ChangeColor2()
    {
        spawningPlayer.GetComponent<Renderer>().material = player2;
    }

    [PunRPC]
    public void ChangeColor3()
    {
        spawningPlayer.GetComponent<Renderer>().material = player3;
    }

    [PunRPC]
    public void ChangeColor4()
    {
        spawningPlayer.GetComponent<Renderer>().material = player4;
    }
}
