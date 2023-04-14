using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private RaycastHit hit;
    public Vector3 distanceToObject;
    private bool pickedUpSomething;
    public GameObject empty;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
            {
                if (hit.transform.tag == "Pickup")
                {
                    if (pickedUpSomething == false)
                    {
                        hit.collider.enabled = false;
                        pickedUpSomething = true;
                        hit.transform.SetParent(empty.transform);
                        hit.transform.localPosition = new Vector3(0, 0, 0);
                        hit.transform.localRotation = new Quaternion (0,0,0,0);
                    }
                }
            }
        }
    }
}
    