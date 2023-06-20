using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SmeltOvenScript : MonoBehaviour
{
    public bool occupied;
    public float timeToWait;
    public int ChildCount;
    public PhotonView view;
    public ParticleSystem rook;
    public Light licht1;
    public Light licht2;
    public bool check;

    public void Update()
    {
        if (transform.Find("Place").transform.childCount == 1)
        {
            occupied = true;
        }
        else
        {
            occupied = false;
        }

        if (occupied == false)
            return;

        StartCoroutine(WaitTime());
    }
    IEnumerator WaitTime()
    {
        view.RPC("StartUX", RpcTarget.All);
        yield return new WaitForSeconds(timeToWait);
        view.RPC("TheEnd", RpcTarget.All);
    }

    [PunRPC]
    public void TheEnd()
    {
        licht1.enabled = false;
        licht2.enabled = false;
    }

    [PunRPC]
    public void StartUX()
    {
        licht1.enabled = true;
        licht2.enabled = true;
    }
}
