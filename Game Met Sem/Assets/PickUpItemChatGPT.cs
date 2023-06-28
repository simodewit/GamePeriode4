using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PickUpItemChatGPT : MonoBehaviourPunCallbacks
{
    public RaycastHit hitPickUp;
    public RaycastHit hitDrop;
    public PhotonView viewOre;
    public GameObject empty;
    public bool inHand;
    public List<string> listOfTags = new List<string>();
    public List<string> listOfTagss = new List<string>();
    public WaveButton waveButton;
    private bool check;
    public GameObject currentObject;
    public GameObject dirtyOre;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Maps"))
        {
            waveButton = GameObject.Find("ActivateWave").GetComponent<WaveButton>();
            check = true;
        }
    }

    private void Update()
    {
        if (!check)
            return;

        if (!photonView.IsMine)
            return;

        if (!waveButton.inWave)
            return;

        if (!Input.GetButtonDown("Fire1"))
            return;

        if (!inHand)
        {
            photonView.RPC("PickUpItem", RpcTarget.All);
        }
        else
        {
            photonView.RPC("DropItems", RpcTarget.All);
        }
    }

    [PunRPC]
    public void PickUpItem()
    {
        Physics.Raycast(transform.position, transform.forward, out hitPickUp, 2);

        if (hitPickUp.transform.CompareTag("Mine"))
        {
            print("penis");
            currentObject = PhotonNetwork.Instantiate("DIRTY ORE", transform.position, Quaternion.identity);
            photonView.RPC("SpecificCode", RpcTarget.All, viewOre.ViewID);
        }
        else if (hitPickUp.transform.CompareTag("Wasbak"))
        {
            if (hitPickUp.transform.GetComponent<WasbakScript>().isWashed)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("Nugget", transform.position, Quaternion.identity);
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
        }
        else if (hitPickUp.transform.CompareTag("SmeltOven"))
        {
            if (hitPickUp.transform.GetComponent<SmeltOvenScript>().isSmelted)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("", transform.position, Quaternion.identity);
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
        }
        else if (hitPickUp.transform.CompareTag("Gietvorm"))
        {
            if (hitPickUp.transform.GetComponent<GietVormScript>().isFormed)
            {
                Destroy(hitPickUp.transform.GetChild(0).gameObject);
                currentObject = PhotonNetwork.Instantiate("", transform.position, Quaternion.identity);
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
            else
            {
                currentObject = hitPickUp.transform.GetChild(0).gameObject;
                photonView.RPC("SpecificCode", RpcTarget.All, currentObject.GetComponent<PhotonView>().ViewID);
            }
        }
    }

    [PunRPC]
    public void DropItems()
    {
        Physics.Raycast(transform.position, transform.forward, out hitDrop, 2);

        bool hasTag = false;
        foreach (string tag in listOfTagss)
        {
            if (hitDrop.transform.CompareTag(tag))
            {
                hasTag = true;
                break;
            }
        }

        if (!hasTag)
            return;

        hitPickUp.transform.SetParent(hitDrop.transform.Find("Place"));
        hitPickUp.transform.localPosition = hitDrop.transform.Find("Place").localPosition;
        hitPickUp.transform.localScale = hitDrop.transform.Find("Place").localScale;
        hitPickUp.transform.rotation = hitDrop.transform.Find("Place").localRotation;
        inHand = false;
    }

    [PunRPC]
    public void SpecificCode(int viewID)
    {
        PhotonView view = PhotonView.Find(viewID);
        view.gameObject.transform.parent = empty.transform;
        view.gameObject.transform.localPosition = hitPickUp.transform.GetComponent<OffsetInfo>().pickupPositionOffset;
        view.gameObject.transform.localRotation = Quaternion.identity;
        view.gameObject.transform.localScale = hitPickUp.transform.GetComponent<OffsetInfo>().pickupScaleOffset;
        inHand = true;
    }
}
