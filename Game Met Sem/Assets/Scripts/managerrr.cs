using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class managerrr : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
    }
}

   

