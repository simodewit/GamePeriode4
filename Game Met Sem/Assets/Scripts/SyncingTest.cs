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

   
    void Update()
    {     
        view.RPC("SetPosition", RpcTarget.All);
    }

    [PunRPC]
    public void SetPosition()
    {
        transform.position = transform.position;
    }
}
