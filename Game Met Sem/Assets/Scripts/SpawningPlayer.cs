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
        test();
        playerCounter = 1;
    }

    [PunRPC]
    public void test()
    {
        print("gets player");
        player = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);
    }

    private void Update()
    {
        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}
