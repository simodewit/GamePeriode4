using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpScriptSemm : MonoBehaviour
{
    public WaveButton waveButton;
    public bool inHand;
    public PhotonView view;
    public RaycastHit hitPickUp;
    public RaycastHit hitNode;
    public RaycastHit hitToRotate;
    public List<string> listOfTags = new();
    public GameObject empty;
    private bool check;

    public void Start()
    {

    }

    public void Update()
    {

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Maps"))
            return;

        if (!check)
        {
            waveButton = GameObject.Find("ActivateWave").GetComponent<WaveButton>();
            check = true;
        }

        if (!view.IsMine)
            return;

        if(waveButton.inWave == true)
            return;

        if (Input.GetButtonDown("Fire2"))
        {
            view.RPC("RotateObject", RpcTarget.All);
        }


        if (!Input.GetButtonDown("Fire1"))
            return;

        if (!inHand)
        {
            view.RPC("PickUpObject", RpcTarget.All);
        }
        else
        {
            view.RPC("DropObject", RpcTarget.All);
        }

    }

    [PunRPC]
    public void PickUpObject()
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

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode);

        hitPickUp.collider.enabled = false;
        hitPickUp.transform.SetParent(empty.transform);
        hitPickUp.transform.localPosition = hitPickUp.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
        hitPickUp.transform.localRotation = Quaternion.identity;
        hitPickUp.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
        hitNode.transform.GetComponent<Node>().occupied = false;
        inHand = true;

    }

    [PunRPC]
    public void DropObject()
    {
        if (!inHand)
            return;

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hitNode, 2);

        if (hitNode.transform.GetComponent<Node>().occupied)
            return;

        hitPickUp.transform.parent = null;
        hitPickUp.collider.enabled = true;
        hitPickUp.transform.localPosition = hitNode.transform.position + hitPickUp.transform.GetComponent<OffsetInfo>().dropPositionOffset;
        hitPickUp.transform.localRotation = Quaternion.identity;
        hitPickUp.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().dropScaleOffset;
        hitNode.transform.GetComponent<Node>().occupied = true;
        inHand = false;

    }

    [PunRPC]
    public void RotateObject()
    {
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

        Physics.Raycast(transform.position, transform.forward, out hitToRotate, 2);

        hitToRotate.transform.Rotate(new Vector3(0, 90, 0));
    }
}
