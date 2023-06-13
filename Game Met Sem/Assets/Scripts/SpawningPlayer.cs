using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawningPlayer : MonoBehaviour
{
    public GameObject player;
    public TMP_Text playerCount;
    void Start()
    {
        
        player = PhotonNetwork.Instantiate("Player 1", transform.position, Quaternion.identity);  
    }
    private void Update()
    {
        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }


}
