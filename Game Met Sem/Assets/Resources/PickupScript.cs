using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private RaycastHit hit;
    private RaycastHit hit1;
    private RaycastHit hit2;
    public Vector3 distanceToObject;
    private bool pickedUpSomething;
    public GameObject empty;
    private bool check;
    private Vector3 placePosition;
    public float radius;
    private bool blueprint;
    public Vector3 blueprintPlacePosition;
    public Quaternion blueprintRotation;

    public void Update()
    {
        check = true;

        if (Input.GetButtonDown("Fire1"))
        {
            if (pickedUpSomething == true)
            {
                if(blueprint == true)
                {
                    hit.transform.parent = null;
                    placePosition = hit1.transform.position;
                    placePosition += blueprintPlacePosition;
                    hit.transform.position = placePosition;
                    hit.transform.localScale = new Vector3(1, 1, 1);
                    hit.collider.enabled = true;
                    pickedUpSomething = false;
                    check = false;
                    hit.transform.localRotation = blueprintRotation;
                }
                else
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

            if(Physics.SphereCast(transform.position, radius, transform.forward, out hit2, 5))
            {
                if(hit2.transform.tag == "Blueprint")
                {
                    if(pickedUpSomething == false)
                    {
                        hit.collider.enabled = false;
                        pickedUpSomething = true;
                        hit.transform.SetParent(empty.transform);
                        hit.transform.localPosition = new Vector3(0, 0, 0);
                        hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                        hit.transform.localScale = new Vector3(1, 1, 1);
                        blueprint = true;
                    }
                }
            }
        }
    }
}
    