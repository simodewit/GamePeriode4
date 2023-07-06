using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OreDirtyPickup : MonoBehaviour
{
    PhotonView view;

    public void Update()
    {
        if(!view.IsMine)
            return;

        if (!Input.GetButtonDown("0"))
            return;
    }
}
