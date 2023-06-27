using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using Photon.Pun;
using System.Diagnostics.CodeAnalysis;
using static UnityEngine.UI.ContentSizeFitter;
using Photon.Pun.Demo.Cockpit;

public class PickupItems : MonoBehaviour
{
    public RaycastHit hitPickUp;
    public RaycastHit hitObject;
    public RaycastHit hitDrop;
    public GameObject empty;
    public bool inHand;
    public PhotonView view;
    public List<string> listOfTags = new();
    public List<string> listOfTagss = new();
    public WaveButton waveButton;
    private bool check;
    public GameObject currentObject;

    public void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Maps"))
            return;

        if (!check)
        {
            waveButton = GameObject.Find("ActivateWave").GetComponent<WaveButton>();
            check = true;
        }

        if (!view.IsMine)
            return;

        if (waveButton.inWave == false)
            return;

        if (!Input.GetButtonDown("Fire1"))
            return;

        print("does work");

        if (!inHand)
        {
            view.RPC("PickUpItem", RpcTarget.All);
        }
        else
        {
            view.RPC("DropItems", RpcTarget.All);
        }
    }

    [PunRPC]
    public void PickUpItem()
    {
        Physics.Raycast(transform.position, transform.forward, out hitPickUp, 2);

        if (hitPickUp.transform.tag == "Mine")
        {
            currentObject = PhotonNetwork.Instantiate("DIRTY ORE", transform.position, Quaternion.identity);
            view.RPC("SpecificCode", RpcTarget.All, currentObject);
        }
        if(hitPickUp.transform.tag == "Wasbak")
        {
            if(hitPickUp.transform.GetComponent<WasbakScript>().isWashed == true)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("Nugget", transform.position, Quaternion.identity);
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
        }
        if (hitPickUp.transform.tag == "SmeltOven")
        {
            if (hitPickUp.transform.GetComponent<SmeltOvenScript>().isSmelted == true)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("", transform.position, Quaternion.identity);
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
        }
        if (hitPickUp.transform.tag == "Gietvorm")
        {
            if(hitPickUp.transform.GetComponent<GietVormScript>().isFormed == true)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("",transform.position, Quaternion.identity);
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                view.RPC("SpecificCode", RpcTarget.All, currentObject);
            }
        }
    }

    [System.Obsolete]
    [PunRPC]
    public void DropItems()
    {
        Physics.Raycast(transform.position, transform.forward, out hitDrop, 2);

        print("wtfff brooo");
        bool hasTag = false;
        for (int i = 0; i < listOfTagss.Count; i++)
        {
            if (hitDrop.transform.tag == listOfTagss[i])
            {
                hasTag = true;
                break;
            }
        }
        if (!hasTag)
            return;

        hitPickUp.transform.SetParent(hitDrop.transform.FindChild("Place").transform);
        hitPickUp.transform.localPosition = hitDrop.transform.FindChild("Place").transform.localPosition;
        hitPickUp.transform.localScale = hitDrop.transform.FindChild("Place").transform.localScale;
        hitPickUp.transform.rotation = hitDrop.transform.FindChild("Place").transform.localRotation;
        inHand = false;
        print("Dropped it");
    }

    [PunRPC]
    public void SpecificCode(GameObject currentObject)
    {
        currentObject.transform.SetParent(empty.transform);
        currentObject.transform.localPosition = hitPickUp.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
        currentObject.transform.localRotation = Quaternion.identity;
        currentObject.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
        inHand = true;
    }






























    //Physics.Raycast(transform.position, transform.forward, out hitPickUp, 2);

    //bool hasTag = false;
    //for (int i = 0; i < listOfTags.Count; i++)
    //{
    //    if (hitPickUp.transform.tag == listOfTags[i])
    //    {
    //        hasTag = true;
    //        break;
    //    }
    //}
    //if (!hasTag)
    //    return;

    //print("PickedUp");
    //Physics.Raycast(empty.transform.position, -empty.transform.up, out hitObject);

    //hitPickUp.collider.enabled = false;
    //hitPickUp.transform.SetParent(empty.transform);
    //hitPickUp.transform.localPosition = hitPickUp.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
    //hitPickUp.transform.localRotation = Quaternion.identity;
    //hitPickUp.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
    //hitObject.transform.GetComponent<Node>().occupied = false;
    //inHand = true;
}
