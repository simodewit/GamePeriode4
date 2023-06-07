using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviourPun
{
    #region variables

    public PhotonView view;
    public GameObject empty;
    public bool inHands;
    private RaycastHit hitNode;
    private RaycastHit hitPickup;
    public WaveButton waveButton;
    public List<string> listOfTags = new();

    #endregion

    #region Pickup code

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if(!view.IsMine)
            return;

        //if()
        {

        }

        if (Input.GetButtonDown("Fire2"))
        {
            view.RPC("RotateObject", RpcTarget.All);
        }

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

        bool hasTag = false;
        for (int i = 0; i < listOfTags.Count; i++)
        {
            if(hitPickup.transform.tag == listOfTags[i])
            {
                hasTag = true;
                break;
            }
        }
        if (!hasTag)
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode);

        hitPickup.collider.enabled = false;
        hitPickup.transform.SetParent(empty.transform);
        hitPickup.transform.localPosition = hitPickup.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = hitPickup.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
        hitNode.transform.GetComponent<Node>().occupied = false;
        inHands = true;
    }

    [PunRPC]
    public void DropObject()
    {
        if(!inHands)
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode, 2);

        if (hitNode.transform.GetComponent<Node>().occupied)
            return;

        hitPickup.transform.parent = null;
        hitPickup.collider.enabled = true;
        hitPickup.transform.localPosition = hitNode.transform.position + hitPickup.transform.GetComponent<OffsetInfo>().dropPositionOffset;
        hitPickup.transform.localRotation = Quaternion.identity;
        hitPickup.transform.localScale = hitPickup.transform.GetComponent<OffsetInfo>().dropScaleOffset;
        hitNode.transform.GetComponent<Node>().occupied = true;
        inHands = false;
    }

    #endregion

    #region RotateObject

    public RaycastHit hitToRotate;

    [PunRPC]

    public void RotateObject()
    {
        bool hasTag = false;
        for (int i = 0; i < listOfTags.Count; i++)
        {
            if (hitPickup.transform.tag == listOfTags[i])
            {
                hasTag = true;
                break;
            }
        }
        if (!hasTag)
            return;

        Physics.Raycast(transform.position, transform.forward, out hitToRotate, 2);

        hitToRotate.transform.Rotate(new Vector3(0, 90, 0));
        print("abc");
    }

    #endregion
}
