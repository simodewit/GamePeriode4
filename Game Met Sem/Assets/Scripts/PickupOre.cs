using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupOre : MonoBehaviour
{
    public PhotonView view;
    private RaycastHit hit;
    private bool inHands;
    private GameObject ore;
    public GameObject empty;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
            {
                if (hit.transform.tag == "Mine")
                {
                    if (inHands == false)
                    {
                        view.RPC("MakeOre", RpcTarget.All);
                    }
                }
                else
                {
                    if (inHands == true)
                    {
                        view.RPC("DeliverOre", RpcTarget.All);
                    }
                }
            }
        }
    }

    [PunRPC]
    public void MakeOre()
    {
        ore = PhotonNetwork.Instantiate("ore", transform.position, Quaternion.identity);
        ore.transform.SetParent(empty.transform);
        inHands = true;
    }

    [PunRPC]
    public void DeliverOre()
    {
        Destroy(ore);
        inHands = false;
        hit.transform.GetComponent<TruckAIScript>().isDelivered = true;
    }
}
