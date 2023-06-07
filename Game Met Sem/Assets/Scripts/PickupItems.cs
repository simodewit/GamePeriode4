using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    public GameObject empty;
    public GameObject Ore;
    public RaycastHit hit;
    public PickupScript pickupScript;

    public void Start()
    {

    }

    public void Update()
    {
        if (!Input.GetButtonDown("Fire1"))
            return;

        if(pickupScript.inHands == true)
            return;

        Physics.Raycast(transform.position, transform.forward, out hit, 2);

        if(hit.transform.tag == "Mine")
        {
            pickupScript.inHands = true;
            Instantiate(Ore, new Vector3 (0,0,0), new Quaternion (0,0,0,0),empty.transform.parent);
        }
    }
}
