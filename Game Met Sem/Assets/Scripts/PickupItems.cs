using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    public GameObject empty;
    public GameObject Ore;
    public RaycastHit hit;

    public void Update()
    {
        if (!Input.GetKeyDown("Fire1"))
            return;

        Physics.Raycast(transform.position, transform.forward, out hit, 2);

        if(hit.transform.tag == "Mine")
        {
            Instantiate(Ore, empty.transform);
        }
    }
}
