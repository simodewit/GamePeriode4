using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SmeltOvenScript : MonoBehaviour
{
    public bool occupied;
    public float timeToWait;
    public int ChildCount;
    public PhotonView view;

    public void Update()
    {
        if(transform.childCount > ChildCount)
        {
            occupied = true;
        }
        else
        {
            occupied = false;
        }

        if(occupied == false) 
            return;

        view.RPC("WaitTime", RpcTarget.All);
    }

    [PunRPC]
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeToWait);
        view.RPC("ChangeObject", RpcTarget.All);
    }

    [System.Obsolete]
    [PunRPC]
    public void ChangeObject()
    {
        PhotonNetwork.Destroy(transform.FindChild("iron ore (vies)").transform.gameObject);
        PhotonNetwork.Instantiate("Nugget", transform.FindChild("Place").transform.position, transform.FindChild("Place").transform.rotation);
    }




}
