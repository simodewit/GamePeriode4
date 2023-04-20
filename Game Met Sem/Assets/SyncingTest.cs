using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncingTest : MonoBehaviour
{
    public PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        PhotonNetwork.SendRate = 200;
        view.RPC("SetPosition", RpcTarget.Others, this.transform.position);
    }

    [PunRPC]
    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
