using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.Burst.CompilerServices;

public class Test : MonoBehaviourPun
{
    [PunRPC]
    private RaycastHit hit1;
    private RaycastHit hit2;
    public Vector3 distanceToObject;
    private bool pickedUpSomething;
    public GameObject empty;
    private Vector3 placePosition;
    public float radius;
    private bool blueprint;
    public Vector3 blueprintPlacePosition;
    public Quaternion blueprintRotation;
    public PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (pickedUpSomething == true)
            {
                DropNormalObject();
                DropBlueprint();
                DropOres();
            }
            else
            {
                PickupNormalObject();
                PickupBlueprint();
                PickupOres();
            }
        }   
    }


    public void PickupNormalObject()
    {
        Physics.Raycast(transform.position, transform.forward, out hit1, 1.5f);

        if (hit1.transform.tag != "Pickup")
        {
            return;
        }

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hit2, 5);

        pickedUpSomething = true;
        hit1.collider.enabled = false;
        hit1.transform.SetParent(empty.transform);
        hit1.transform.localPosition = new Vector3(0, 0, 0);
        hit1.transform.localRotation = new Quaternion(0, 0, 0, 0);
        hit1.transform.localScale = new Vector3(1, 1, 1);
        hit2.transform.GetComponent<Node>().occupied = false;
    }


    public void DropNormalObject()
    {
        if(hit1.transform.tag != "Pickup")
        {
            return;
        }

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hit2, 5);

        if(hit2.transform.GetComponent<Node>().occupied == true)
        {
            return;
        }

        hit1.transform.parent = null;
        placePosition = hit1.transform.position;
        placePosition.y += 1;
        hit1.transform.position = placePosition;
        hit1.transform.localScale = new Vector3(1, 1, 1);
        hit1.collider.enabled = true;
        pickedUpSomething = false;
        hit1.transform.localRotation = new Quaternion(0, 0, 0, 0);
        hit1.transform.GetComponent<Node>().occupied = true;
    }


    public void PickupBlueprint()
    {
        Physics.SphereCast(transform.position, radius, transform.forward, out hit2, 5);

        if (hit2.transform.tag != "Blueprint")
        {
            return;
        }

        if (pickedUpSomething == true)
        {
            return;
        }

        hit1.collider.enabled = false;
        pickedUpSomething = true;
        hit1.transform.SetParent(empty.transform);
        hit1.transform.localPosition = new Vector3(0, 0, 0);
        hit1.transform.localRotation = new Quaternion(0, 0, 0, 0);
        hit1.transform.localScale = new Vector3(1, 1, 1);
        blueprint = true;
    }

    public void DropBlueprint()
    {
        if(blueprint == false)
        {
            return;
        }

        if(pickedUpSomething == false)
        {
            return;
        }

        Physics.Raycast(empty.transform.position, -empty.transform.up, out hit1, 5);

        hit1.transform.parent = null;
        placePosition = hit1.transform.position;
        placePosition += blueprintPlacePosition;
        hit1.transform.position = placePosition;
        hit1.transform.localScale = new Vector3(1, 1, 1);
        hit1.collider.enabled = true;
        pickedUpSomething = false;
        hit1.transform.localRotation = blueprintRotation;
        hit1.transform.GetComponent<Node>().occupied = true;
        print("5");
    }

    public void PickupOres()
    {

    }

    public void DropOres()
    {

    }
}
