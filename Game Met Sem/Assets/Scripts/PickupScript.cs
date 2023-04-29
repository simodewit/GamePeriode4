using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Photon.Pun;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviourPun
{
    public PhotonView view;
    public GameObject empty;
    private bool inHands;
    private bool isPickup;
    private bool isBlueprint;
    private RaycastHit hitNode;
    private RaycastHit hitPickup;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if(!view.IsMine)
            return;

        if(!Input.GetButtonDown("Fire1"))
            return;

        if (!inHands)
        {
            view.RPC("PickupObject", RpcTarget.All);
        }
        else
        {
            view.RPC("DropObject", RpcTarget.All);
        }
    }


    [PunRPC]
    public void PickupObject()
    {
        Physics.Raycast(transform.position, transform.forward, out hitPickup, 2);

        if (hitPickup.transform.tag != "Pickup")
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode);

        hitPickup.collider.enabled = false;
        inHands = true;
        hitPickup.transform.SetParent(empty.transform);
        hitPickup.transform.localPosition = Vector3.zero;
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = Vector3.one;
        hitNode.transform.GetComponent<Node>().occupied = false;
        isPickup = true;
    }

    [PunRPC]
    public void DropObject()
    {
        if(!isPickup)
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode, 2);

        if (hitNode.transform.GetComponent<Node>().occupied)
            return;

        hitPickup.transform.parent = null;
        hitPickup.collider.enabled = true;
        hitPickup.transform.localPosition = hitNode.transform.position + new Vector3 (0,1,0);
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = Vector3.one;
        hitNode.transform.GetComponent<Node>().occupied = true;
        inHands = false;
        isPickup = false;
    }
}
    