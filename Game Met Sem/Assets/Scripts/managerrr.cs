using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class managerrr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity);
    }
}

   

