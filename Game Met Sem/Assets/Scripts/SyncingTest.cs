using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncingTest : MonoBehaviour, IPunObservable
{
    public PhotonView view;
    public Vector3 trackPos;
    public Quaternion trackRot;
    public Transform[] pickupbleObject;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

   
    void Update()
    {
        if (!view.IsMine)
        {
            pickupbleObject[0].position = trackPos;
            pickupbleObject[0].rotation = trackRot;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(pickupbleObject[0].position);
            stream.SendNext(pickupbleObject[0].rotation);
        }

        if (stream.IsReading)
        {
            trackPos = (Vector3)stream.ReceiveNext();
            trackRot = (Quaternion)stream.ReceiveNext();
        }



    }
}
