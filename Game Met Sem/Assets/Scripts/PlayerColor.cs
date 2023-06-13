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
    public bool check1;
    public bool check2;
    public bool check3;
    public bool check4;
    public GameObject spawningPlayer;
    void Start()
    {
        view = GetComponent<PhotonView>();
        spawningPlayer = GameObject.Find("LobbyManager").GetComponent<SpawningPlayer>().player;
        view.RPC("ChangeColor", RpcTarget.All);
    }

    [PunRPC]
    public void ChangeColor()
    {
        if (view.IsMine)
        {
            if (check1 == false)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
                {
                    spawningPlayer.GetComponent<Renderer>().material = player1;
                    print("mat1");
                }
                check1 = true;
            }

            if (check2 == false)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                {
                    spawningPlayer.GetComponent<Renderer>().material = player2;
                    print("mat2");
                }
                check2 = true;
            }
                


            if (check3 == false)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
                {
                    spawningPlayer.GetComponent<Renderer>().material = player3;
                    print("mat3");
                }
                check3 = true;
            }
  
            if (check4 == false)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
                {
                    spawningPlayer.GetComponent<Renderer>().material = player4;
                    print("mat4");
                }
                check4 = true;
            }
               
        }       
    }
}
