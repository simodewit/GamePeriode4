using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawningPlayer : MonoBehaviour
{
    public GameObject player;
    public TMP_Text playerCount;
    public PhotonView view;
    public int playerCounter;

    void Awake()
    {
        view.RPC("test", RpcTarget.All);
        playerCounter = 1;
        
    }

    [PunRPC]
    public void test()
    {
        print("1");
        player = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
    }

    private void Update()
    {
        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();

        if(PhotonNetwork.CurrentRoom.PlayerCount > playerCounter)
        {
            view.RPC("test", RpcTarget.All);
        }

        playerCounter = PhotonNetwork.CurrentRoom.PlayerCount;
    }


}
