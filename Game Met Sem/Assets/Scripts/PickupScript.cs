using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Photon.Pun;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviourPun
{
    #region variables

    public PhotonView view;
    public GameObject empty;
    private bool inHands;
    private RaycastHit hitNode;
    private RaycastHit hitPickup;

    #endregion

    #region main code

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
    public void PickupObject(Vector3 scale, Vector3 position)
    {
        Physics.Raycast(transform.position, transform.forward, out hitPickup, 2);

        if (hitPickup.transform.tag != "Pickup")
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode);

        hitPickup.collider.enabled = false;
        hitPickup.transform.SetParent(empty.transform);
        hitPickup.transform.localPosition = position;
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = scale;
        hitNode.transform.GetComponent<Node>().occupied = false;
        inHands = true;
    }

    [PunRPC]
    public void DropObject(Vector3 scale, Vector3 positionOffset)
    {
        if(!inHands)
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode, 2);

        if (hitNode.transform.GetComponent<Node>().occupied)
            return;

        hitPickup.transform.parent = null;
        hitPickup.collider.enabled = true;
        hitPickup.transform.localPosition = hitNode.transform.position + positionOffset;
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = scale;
        hitNode.transform.GetComponent<Node>().occupied = true;
        inHands = false;
    }

    #endregion
}
