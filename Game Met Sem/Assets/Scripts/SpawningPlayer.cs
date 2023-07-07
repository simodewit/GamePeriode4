using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using JetBrains.Annotations;
using Photon.Realtime;

public class SpawningPlayer : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        PhotonNetwork.Instantiate("character voor game (1) (1) Variant", transform.position, Quaternion.identity);
    }
}
