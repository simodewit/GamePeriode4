using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OreDirtyPickup : MonoBehaviour
{
    public GameObject empty;
    public GameObject Ore;
    public RaycastHit hit;
    public PickupScript pickupScript;
    public WaveButton waveButton;
    public GameObject currentItem;

    public void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Maps"))
            return;

        waveButton = GameObject.Find("ActivateWave").GetComponent<WaveButton>();
    }

    public void Update()
    {
        if (!Input.GetButtonDown("Fire1"))
            return;

        if (waveButton.inWave == false)
            return;

        Physics.Raycast(transform.position, transform.forward, out hit, 2);

        if (pickupScript.inHands == true)
        {
            if(hit.transform.tag != "Table")
                return;

            DropItemOnTable();
        }
        else
        {
            if (hit.transform.tag == "Mine")
            {
                PickupOreFromMine();
            }
            else if(hit.transform.tag == "Table")
            {
                PickupItemFromTable();
            }
        }
    }

    public void PickupOreFromMine()
    {
        pickupScript.inHands = true;
        currentItem = Instantiate(Ore, empty.transform.position, empty.transform.rotation, empty.transform.parent);
        currentItem.transform.position -= new Vector3(0, 0, -0.2f);
    }

    public void PickupItemFromTable()
    {
        pickupScript.inHands = true;
        currentItem = hit.transform.Find("HoldingPlace").transform.GetChild(0).gameObject;
        currentItem.transform.SetParent(empty.transform);
    }

    public void DropItemOnTable()
    {
        pickupScript.inHands = false;
        pickupScript.inHands = false;
        currentItem.transform.parent = null;
        currentItem.transform.SetParent(hit.transform);
        currentItem.transform.position = hit.transform.position + new Vector3(0, 1, 0);
    }
}
