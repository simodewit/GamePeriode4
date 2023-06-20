using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using JetBrains.Annotations;
using Photon.Realtime;

public class SpawningPlayer : MonoBehaviourPunCallbacks
{
    //public PhotonView view;
    //public GameObject playerPrefab;
    //public GameObject currentPlayer;
    //public GameObject hostPlayer;
    //public GameObject[] players;
    //public Material[] materials;
    //public GameObject panelHostLeave;
    //public GameObject panelMoreThanFourPlayers;

    //public void Start()
    //{
    //    view = gameObject.GetComponent<PhotonView>();
    //    panelHostLeave = GameObject.Find("HostLeave");
    //    panelMoreThanFourPlayers = GameObject.Find("FivePlayers");

    //    if(!view.IsMine)
    //        return;

    //    if (PhotonNetwork.CurrentRoom.PlayerCount != 1)
    //        view.RPC("OtherPlayer", RpcTarget.All);

    //    view.RPC("FirstPlayer", RpcTarget.All);
    //}

    //public void Update()
    //{
    //    if(hostPlayer == null)
    //    {
    //        panelHostLeave.SetActive(true);
    //    }
    //}

    //public void FirstPlayer()
    //{
    //    currentPlayer = PhotonNetwork.Instantiate("PlayerCharacter Variant", transform.position, Quaternion.identity);
    //    currentPlayer.GetComponent<Renderer>().material = materials[1];
    //    players[PhotonNetwork.CurrentRoom.PlayerCount] = playerPrefab;
    //    gameObject.name = "MainPlayer";
    //}

    //public void OtherPlayer()
    //{
    //    currentPlayer = PhotonNetwork.Instantiate("PlayerCharacter Variant", new Vector3 (0,1,0), Quaternion.identity);
    //    hostPlayer = GameObject.Find("MainPlayer");

    //    if (hostPlayer.GetComponent<SpawningPlayer>().players[2] == null)
    //    {
    //        gameObject.name = "Player2";
    //        hostPlayer.GetComponent<SpawningPlayer>().players[2] = playerPrefab;
    //        currentPlayer.GetComponent<Renderer>().material = materials[2];
    //    }
    //    else if (hostPlayer.GetComponent<SpawningPlayer>().players[3] == null)
    //    {
    //        gameObject.name = "Player3";
    //        hostPlayer.GetComponent<SpawningPlayer>().players[3] = playerPrefab;
    //        currentPlayer.GetComponent<Renderer>().material = materials[3];
    //    }
    //    else if (hostPlayer.GetComponent<SpawningPlayer>().players[4] == null)
    //    {
    //        gameObject.name = "Player4";
    //        hostPlayer.GetComponent<SpawningPlayer>().players[4] = playerPrefab;
    //        currentPlayer.GetComponent<Renderer>().material = materials[4];
    //    }
    //    else
    //    {
    //        panelMoreThanFourPlayers.SetActive(true);
    //    }
    //}



    public PhotonView view;
    public GameObject panelFivePlayers;
    public GameObject panelHostLeft;
    public GameObject[] players;
    public Material[] materials;

    public void Start()
    {
        print("first frame before update");
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
            return;

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            print("Spawn host player");
            view.RPC("HostClient", RpcTarget.All);
            return;
        }
        print("Spawn normal player");
        view.RPC("NormalClients", RpcTarget.All);
    }

    public void Update()
    {
        if (players[0] == null)
        {
            print("Host left the session");
            view.RPC("HostLeft", RpcTarget.All);
        }
    }

    [PunRPC]
    public void HostClient()
    {
        players[0] = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
        players[0].GetComponent<Renderer>().material = materials[0];
    }

    [PunRPC]
    public void NormalClients()
    {
        if (players[1] != null)
        {
            print("player two spawns");
            players[1] = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
            players[1].GetComponent<Renderer>().material = materials[1];
            return;
        }
        else if (players[2] != null)
        {
            print("player three spawns");
            players[2] = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
            players[2].GetComponent<Renderer>().material = materials[2];
            return;
        }
        else if (players[3] != null)
        {
            print("player four spawns");
            players[3] = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
            players[3].GetComponent<Renderer>().material = materials[3];
            return;
        }
        else
        {
            print("more than four players active");
            panelFivePlayers.SetActive(true);
        }
    }

    [PunRPC]
    public void HostLeft()
    {
        panelHostLeft.SetActive(true);
    }
}
