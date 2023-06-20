using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using JetBrains.Annotations;
using Photon.Realtime;

public class SpawningPlayer : MonoBehaviourPunCallbacks
{
    public PhotonView view;
    public GameObject playerPrefab;
    public GameObject currentPlayer;
    public GameObject hostPlayer;
    public GameObject[] players;
    public Material[] materials;

    public void Start()
    {
        if(!view.IsMine)
            return;

        if (PhotonNetwork.CurrentRoom.PlayerCount != 1)
            view.RPC("OtherPlayer", RpcTarget.All);

        view.RPC("FirstPlayer", RpcTarget.All);
    }

    public void Update()
    {
        if(hostPlayer == null)
        {
            view.RPC("MigrateHost", RpcTarget.All);
        }
    }

    public void MirgrateHost()
    {
        
    }

    public void FirstPlayer()
    {
        currentPlayer = PhotonNetwork.Instantiate("PlayerCharacter Variant", transform.position, Quaternion.identity);
        currentPlayer.GetComponent<Renderer>().material = materials[1];
        players[PhotonNetwork.CurrentRoom.PlayerCount] = playerPrefab;
        gameObject.name = "MainPlayer";
    }

    public void OtherPlayer()
    {
        currentPlayer = PhotonNetwork.Instantiate("PlayerCharacter Variant", transform.position, Quaternion.identity);
        hostPlayer = GameObject.Find("MainPlayer");

        if (hostPlayer.GetComponent<SpawningPlayer>().players[1] == null)
        {
            gameObject.name = "Player1";
            hostPlayer.GetComponent<SpawningPlayer>().players[1] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[1];
        }
        if (hostPlayer.GetComponent<SpawningPlayer>().players[2] == null)
        {
            gameObject.name = "Player2";
            hostPlayer.GetComponent<SpawningPlayer>().players[2] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[2];
        }
        if (hostPlayer.GetComponent<SpawningPlayer>().players[3] == null)
        {
            gameObject.name = "Player3";
            hostPlayer.GetComponent<SpawningPlayer>().players[3] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[3];
        }
        if (hostPlayer.GetComponent<SpawningPlayer>().players[4] == null)
        {
            gameObject.name = "Player4";
            hostPlayer.GetComponent<SpawningPlayer>().players[4] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[4];
        }
    }
}
