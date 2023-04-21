using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncingTest : MonoBehaviour, IPunObservable
{
    public PhotonView view;
    public Vector3 trackPos;
    public Quaternion trackRot;
    public Vector3 trackScale;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

   
    void Update()
    {
        if (!view.IsMine)
        {
            transform.position = trackPos;
            transform.rotation = trackRot;
            transform.localScale = trackScale;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(transform.localScale);

        }

        if (stream.IsReading)
        {
            trackPos = (Vector3)stream.ReceiveNext();
            trackRot = (Quaternion)stream.ReceiveNext();
            trackScale = (Vector3)stream.ReceiveNext();
        }



    }
}
