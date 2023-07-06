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

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if(!view.IsMine)
            return;

        //spawningPlayer = GameObject.Find("LobbyManager").GetComponent<SpawningPlayer>().player;

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
        player1Prefab = spawningPlayer;
    }

    [PunRPC]
    public void ChangeColor2()
    {
        player2Prefab = spawningPlayer;
        player1Prefab.GetComponent<Renderer>().material = player1;
        spawningPlayer.GetComponent<Renderer>().material = player2;
    }

    [PunRPC]
    public void ChangeColor3()
    {
        player3Prefab = spawningPlayer;
        player1Prefab.GetComponent<Renderer>().material = player1;
        player2Prefab.GetComponent<Renderer>().material = player2;
        spawningPlayer.GetComponent<Renderer>().material = player3;
    }

    [PunRPC]
    public void ChangeColor4()
    {
        player1Prefab.GetComponent<Renderer>().material = player1;
        player2Prefab.GetComponent<Renderer>().material = player2;
        player3Prefab.GetComponent<Renderer>().material = player3;
        spawningPlayer.GetComponent<Renderer>().material = player4;
    }
}
