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
    public GameObject panelHostLeave;
    public GameObject panelMoreThanFourPlayers;

    public void Start()
    {
        view = gameObject.GetComponent<PhotonView>();
        panelHostLeave = GameObject.Find("HostLeave");
        panelMoreThanFourPlayers = GameObject.Find("FivePlayers");

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
            panelHostLeave.SetActive(true);
        }
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
        currentPlayer = PhotonNetwork.Instantiate("PlayerCharacter Variant", new Vector3 (0,1,0), Quaternion.identity);
        hostPlayer = GameObject.Find("MainPlayer");

        if (hostPlayer.GetComponent<SpawningPlayer>().players[2] == null)
        {
            gameObject.name = "Player2";
            hostPlayer.GetComponent<SpawningPlayer>().players[2] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[2];
        }
        else if (hostPlayer.GetComponent<SpawningPlayer>().players[3] == null)
        {
            gameObject.name = "Player3";
            hostPlayer.GetComponent<SpawningPlayer>().players[3] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[3];
        }
        else if (hostPlayer.GetComponent<SpawningPlayer>().players[4] == null)
        {
            gameObject.name = "Player4";
            hostPlayer.GetComponent<SpawningPlayer>().players[4] = playerPrefab;
            currentPlayer.GetComponent<Renderer>().material = materials[4];
        }
        else
        {
            panelMoreThanFourPlayers.SetActive(true);
        }
    }
}
