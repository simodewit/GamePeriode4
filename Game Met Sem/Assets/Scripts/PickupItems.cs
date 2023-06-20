using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using Photon.Pun;

public class PickupItems : MonoBehaviour
{
    public RaycastHit hitPickUp;
    public RaycastHit hitObject;
    public RaycastHit hitDrop;
    public GameObject empty;
    public bool inHand;
    public PhotonView view;
    public List<string> listOfTags = new();
    public WaveButton waveButton;
    private bool check;

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

        if (!inHand)
        {
            view.RPC("PickUpItem", RpcTarget.All);
        }
        else
        {
            view.RPC("DropItem", RpcTarget.All);
        }
    }

    [PunRPC]
    public void PickUpItem()
    {
        Physics.Raycast(transform.position, transform.forward, out hitPickUp, 2);

        bool hasTag = false;
        for (int i = 0; i < listOfTags.Count; i++)
        {
            if (hitPickUp.transform.tag == listOfTags[i])
            {
                hasTag = true;
                break;
            }
        }
        if (!hasTag)
            return;

        print("PickedUp");
        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitObject);

        hitPickUp.collider.enabled = false;
        hitPickUp.transform.SetParent(empty.transform);
        hitPickUp.transform.localPosition = hitPickUp.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
        hitPickUp.transform.localRotation = Quaternion.identity;
        hitPickUp.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
        hitObject.transform.GetComponent<Node>().occupied = false;
        inHand = true;
    }

    [System.Obsolete]
    public void DropItems()
    {
        Physics.Raycast(transform.position, transform.forward, out hitDrop, 2);

        bool hasTag = false;
        for (int i = 0; i < listOfTags.Count; i++)
        {
            if (hitDrop.transform.tag == listOfTags[i])
            {
                hasTag = true;
                break;
            }
        }
        if (!hasTag)
            return;

        hitPickUp.transform.SetParent(empty.transform);
        hitPickUp.transform.localPosition = hitDrop.transform.FindChild("Place").transform.localPosition;
        hitPickUp.transform.localScale = hitDrop.transform.FindChild("Place").transform.localScale;
        hitPickUp.transform.rotation = hitDrop.transform.FindChild("Place").transform.localRotation;
        inHand = false;


    }
}
