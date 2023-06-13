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

    void Awake()
    {
        view.RPC("test", RpcTarget.All);
    }

    public void test()
    {
        player = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
    }

    private void Update()
    {
        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }


}
