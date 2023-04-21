using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Test30005 : MonoBehaviour
{
    public PhotonView photonView;
    public Vector3 trackPos;

    private void Start()
    {
        trackPos = transform.position;
    }

    public void Update()
    {
        if (photonView.IsMine)
        {
            transform.position += trackPos;
        }
        else
        {
            photonView.RPC("posChangeRPC", photonView.Owner, trackPos);
        }
    }

    [PunRPC]
    public void posChangeRPC(Vector3 posChange)
    {
        transform.position += posChange;
    }
}
