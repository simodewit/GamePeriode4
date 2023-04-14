using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private RaycastHit hit;
    private RaycastHit hit1;
    public Vector3 distanceToObject;
    private bool pickedUpSomething;
    public GameObject empty;
    private bool check;
    private Vector3 placePosition;

    public void Update()
    {
        check = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpSomething == true)
            {
                if (Physics.Raycast(hit.transform.position, -hit.transform.up, out hit1, 5))
                {
                    hit.transform.parent = null;
                    placePosition = hit1.transform.position;
                    placePosition.y += 1;
                    hit.transform.position = placePosition;
                    hit.transform.localScale = new Vector3(1, 1, 1);
                    hit.collider.enabled = true;
                    pickedUpSomething = false;
                    check = false;
                    hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                }
            }

            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
            {
                if (hit.transform.tag == "Pickup")
                {
                    if (pickedUpSomething == false)
                    {
                        if (check == true)
                        {
                            hit.collider.enabled = false;
                            pickedUpSomething = true;
                            hit.transform.SetParent(empty.transform);
                            hit.transform.localPosition = new Vector3(0, 0, 0);
                            hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                            hit.transform.localScale = new Vector3(1, 1, 1);
                        }
                    }
                }
            }
        }
    }
}
    