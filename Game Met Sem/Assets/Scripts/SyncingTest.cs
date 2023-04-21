using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncingTest : MonoBehaviour, IPunObservable
{
    public PhotonView view;
    public Vector3 trackPos;
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

   
    void Update()
    {
        if (!view.IsMine)
        {
            transform.position = trackPos;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }

        if (stream.IsReading)
        {
            trackPos = (Vector3)stream.ReceiveNext();
        }



    }
}
